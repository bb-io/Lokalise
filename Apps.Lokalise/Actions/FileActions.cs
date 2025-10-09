using RestSharp;
using System.IO.Compression;
using System.Net.Mime;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Apps.Lokalise.Models.Requests.Files;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Apps.Lokalise.Utils.Converters;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Xliff.Utils.Extensions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Apps.Lokalise.Models.Responses.Glossary;
using Blackbird.Applications.Sdk.Glossaries.Utils.Dtos;
using Blackbird.Applications.Sdk.Glossaries.Utils.Converters;
using System.Xml.Linq;

namespace Apps.Lokalise.Actions;

[ActionList("Files")]
public class FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : LokaliseInvocable(invocationContext)
{
    #region Actions

    [Action("Get project files", Description = "Get all project files")]
    public async Task<ListAllFilesResponse> ListAllFiles([ActionParameter] ListAllFilesRequest input)
    {
        var endpoint =
            $"/projects/{input.ProjectId}/files?filter_filename={input.FilterFileName}";

        var items = await Paginator.GetAll<FilesWrapper, FileInfoDto>(Creds, endpoint);

        return new(items);
    }

    [Action("Upload file to project", Description = "Upload file to project")]
    public async Task<QueuedProcessDto> UploadFile([ActionParameter] ProjectRequest project,
        [ActionParameter] UploadFileInput input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/upload";
        var request =
            new LokaliseRequest(endpoint, Method.Post, Creds).WithJsonBody(
                new UploadFileRequest(input, fileManagementClient));
        var uploadResult = await Client.ExecuteWithHandling<QueuedProcessDto>(request);

        return await Client
            .PollFileImportOperation(project.ProjectId, uploadResult.Process.ProcessId, Creds);
    }
    
    [Action("Upload file to project as XLIFF", Description = "Upload file to project as XLIFF")]
    public async Task<QueuedProcessDto> UploadFileAsXliff([ActionParameter] ProjectRequest project,
        [ActionParameter] UploadXliffInput input)
    {
        if(input.File.Name.EndsWith(".mqxliff"))
        {        
            var stream = await fileManagementClient.DownloadAsync(input.File);
            var fileReference = await ConvertMqXliffToXliff(stream, input.File.Name);
            input.File = fileReference;
            return await UploadFile(project, input);
        }

        if (input.OverwriteExistingKeys.HasValue && input.OverwriteExistingKeys.Value)
        {
            var fileStream = await fileManagementClient.DownloadAsync(input.File);
            var stream = new MemoryStream();
            await fileStream.CopyToAsync(stream);
            stream.Position = 0;
            
            var xliff = stream.ToXliffDocument();
            var newTranslationUnits = xliff.TranslationUnits.Select(x =>
            {
                x.Attributes.Add("old_id", x.Id);
                x.Id = x.Attributes["resname"];
                return x;
            }).ToList();
            xliff = xliff.RemoveTranslationUnits();
            var xDocument = xliff.UpdateTranslationUnits(newTranslationUnits, true);
        
            var xliffStream = xDocument.ToStream();
            input.File = await fileManagementClient.UploadAsync(xliffStream, MediaTypeNames.Text.Xml, input.File.Name);
        }
        
        return await UploadFile(project, input);
    }

    [Action("Download all project files as ZIP", Description = "Download all project files as ZIP archive")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadProjectFilesAsZip(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/async-download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(input);

        var asyncProcessResult = await Client.ExecuteWithHandling<AsyncProcessInitResponse>(request);

        string processId = asyncProcessResult.ProcessId ?? throw new PluginApplicationException("Process ID is null in async download response.");
        AsyncProcessResponse processStatus = null;
        var processEndpoint = $"/projects/{project.ProjectId}/processes/{processId}";
        var processRequest = new LokaliseRequest(processEndpoint, Method.Get, Creds);
        processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(processRequest);

        if (processStatus?.Process?.Status == null)
        {
            throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
        }

        if (processStatus.Process.Type != "async-export")
        {
            throw new PluginApplicationException($"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
        }

        while (processStatus.Process.Status == "queued" ||
               processStatus.Process.Status == "pre_processing" ||
               processStatus.Process.Status == "running" ||
               processStatus.Process.Status == "post_processing")
        {

            processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(new LokaliseRequest(processEndpoint, Method.Get, Creds));

            if (processStatus?.Process?.Status == null)
            {
                throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
            }

            if (processStatus.Process.Type != "async-export")
            {
                throw new PluginApplicationException($"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
            }
        }

        if (processStatus.Process.Status != "finished")
        {
            throw new PluginApplicationException($"File download process failed with status: {processStatus.Process.Status}, message: {processStatus.Process.Message ?? "No message provided"} for process_id: {processId}");
        }

        if (string.IsNullOrEmpty(processStatus.Process.Details.DownloadUrl))
        {
            throw new PluginApplicationException($"Download URL is null or empty in finished process response for process_id: {processId}");
        }

        var fileUri = new Uri(processStatus.Process.Details.DownloadUrl);
        var zipResponse = await Client.ExecuteWithHandling(new(fileUri));

        await using var zipStream = new MemoryStream();
        using (var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, leaveOpen: true))
        {
            var rawBytes = zipResponse.RawBytes ?? throw new PluginApplicationException("Downloaded file content is null.");
            using (var sourceMs = new MemoryStream(rawBytes))
            using (var sourceArchive = new ZipArchive(sourceMs, ZipArchiveMode.Read, leaveOpen: false))
            {
                foreach (var entry in sourceArchive.Entries.Where(e => !e.FullName.EndsWith('/')))
                {
                    using var entryStream = entry.Open();
                    using var bufferedStream = new MemoryStream();
                    await entryStream.CopyToAsync(bufferedStream);
                    bufferedStream.Position = 0;

                    var zipEntry = zipArchive.CreateEntry(entry.FullName);
                    using var zipEntryStream = zipEntry.Open();
                    await bufferedStream.CopyToAsync(zipEntryStream);
                }
            }
        }
        zipStream.Position = 0;

        var fileName = fileUri.Segments.Last();
        if (!fileName.Contains("."))
        {
            fileName += ".zip";
        }
        var zipFileReference = await fileManagementClient.UploadAsync(
            zipStream,
            contentType: zipResponse.ContentType ?? MediaTypeNames.Application.Octet,
            fileName: fileName);

        return new DownloadProjectFilesAsZipResponse { File = zipFileReference };
    }

    [Action("Download project source files", Description = "Download all project source files")]
    public async Task<DownloadFilesResponse> DownloadProjectSourceFiles(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadSourceFilesRequest input)
    {
        var projectData = await new ProjectActions(InvocationContext).RetrieveProject(project);

        var endpoint = $"/projects/{project.ProjectId}/files/async-download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new DownloadFileRequest
            {
                Format = input.Format
            });

        var asyncProcessResult = await Client.ExecuteWithHandling<AsyncProcessInitResponse>(request);
        string processId = asyncProcessResult.ProcessId
            ?? throw new PluginApplicationException("Process ID is null in async download response.");

        AsyncProcessResponse processStatus;
        var processEndpoint = $"/projects/{project.ProjectId}/processes/{processId}";
        var processRequest = new LokaliseRequest(processEndpoint, Method.Get, Creds);

        processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(processRequest);
        if (processStatus?.Process?.Status == null)
        {
            throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
        }
        if (processStatus.Process.Type != "async-export")
        {
            throw new PluginApplicationException(
                $"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
        }

        while (processStatus.Process.Status == "queued" ||
               processStatus.Process.Status == "pre_processing" ||
               processStatus.Process.Status == "running" ||
               processStatus.Process.Status == "post_processing")
        {
            processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(new LokaliseRequest(processEndpoint, Method.Get, Creds));

            if (processStatus?.Process?.Status == null)
            {
                throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
            }
            if (processStatus.Process.Type != "async-export")
            {
                throw new PluginApplicationException(
                    $"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
            }
        }

        if (processStatus.Process.Status != "finished")
        {
            throw new PluginApplicationException(
                $"File export process failed with status: {processStatus.Process.Status}, " +
                $"message: {processStatus.Process.Message ?? "No message provided"} for process_id: {processId}");
        }

        var downloadUrl = processStatus.Process.Details.DownloadUrl;
        if (string.IsNullOrEmpty(downloadUrl))
        {
            throw new PluginApplicationException(
                $"Download URL is null or empty in finished process response for process_id: {processId}");
        }

        var fileUri = new Uri(downloadUrl);
        var zipResponse = await Client.ExecuteWithHandling(new RestRequest(fileUri));

        var rawBytes = zipResponse.RawBytes
            ?? throw new PluginApplicationException("Downloaded file content is null.");

        await using var zipStream = new MemoryStream(rawBytes);
        using var sourceArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: false);

        var result = new List<FileReference>();
        foreach (var entry in sourceArchive.Entries.Where(e => !e.FullName.EndsWith('/')))
        {
            using var entryStream = entry.Open();
            using var bufferedStream = new MemoryStream();
            await entryStream.CopyToAsync(bufferedStream);
            bufferedStream.Position = 0;

            var segments = entry.FullName.Split('/');
            var languageCode = segments[0];
            var originalFileName = Path.GetFileName(entry.FullName);
            var newFileName = $"{languageCode}_{originalFileName}";

            var uploaded = await fileManagementClient.UploadAsync(
                bufferedStream,
                contentType: "application/octet-stream",
                fileName: newFileName
            );

            result.Add(uploaded);
        }

        return new DownloadFilesResponse(result.ToArray());
    }

    [Action("Download translated project file", Description = "Download translated project file by name")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadTranslatedFile(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTranslatedFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/async-download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new DownloadFileRequest
            {
                Format = input.Format,
                OriginalFilenames = input.OriginalFilenames,
                BundleStructure = input.BundleStructure,
                DirectoryPrefix = input.DirectoryPrefix,
                AllPlatforms = input.AllPlatforms,
                FilterLangs = input.FilterLangs,
                FilterData = input.FilterData,
                FilterFilenames = input.FilterFilenames,
                AddNewlineEof = input.AddNewlineEof,
                CustomTranslationStatusIds = input.CustomTranslationStatusIds,
                IncludeTags = input.IncludeTags,
                ExcludeTags = input.ExcludeTags,
                ExportSort = input.ExportSort,
                ExportEmptyAs = input.ExportEmptyAs,
                ExportNullAs = input.ExportNullAs,
                IncludeComments = input.IncludeComments,
                IncludeDescription = input.IncludeDescription,
                IncludePids = input.IncludePids,
                Triggers = input.Triggers,
                FilterRepositories = input.FilterRepositories,
                ReplaceBreaks = input.ReplaceBreaks,
                DisableReferences = input.DisableReferences,
                PluralFormat = input.PluralFormat,
                PlaceholderFormat = input.PlaceholderFormat,
                WebhookUrl = input.WebhookUrl,
                LanguageMapping = input.LanguageMapping,
                IcuNumeric = input.IcuNumeric,
                EscapePercent = input.EscapePercent,
                Indentation = input.Indentation,
                YamlIncludeRoot = input.YamlIncludeRoot,
                JsonUnescapedSlashes = input.JsonUnescapedSlashes,
                JavaPropertiesEncoding = input.JavaPropertiesEncoding,
                JavaPropertiesSeparator = input.JavaPropertiesSeparator,
                BundleDescription = input.BundleDescription,
                FilterTaskId = input.FilterTaskId,
                Compact = input.Compact
            });

        var asyncProcessResult = await Client.ExecuteWithHandling<AsyncProcessInitResponse>(request);
        string processId = asyncProcessResult.ProcessId
            ?? throw new PluginApplicationException("Process ID is null in async download response.");

        var processEndpoint = $"/projects/{project.ProjectId}/processes/{processId}";
        var processRequest = new LokaliseRequest(processEndpoint, Method.Get, Creds);

        var processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(processRequest);
        if (processStatus?.Process?.Status == null)
        {
            throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
        }
        if (processStatus.Process.Type != "async-export")
        {
            throw new PluginApplicationException(
                $"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
        }

        while (processStatus.Process.Status == "queued" ||
               processStatus.Process.Status == "pre_processing" ||
               processStatus.Process.Status == "running" ||
               processStatus.Process.Status == "post_processing")
        {
            processStatus = await Client.ExecuteWithHandling<AsyncProcessResponse>(
                new LokaliseRequest(processEndpoint, Method.Get, Creds)
            );

            if (processStatus?.Process?.Status == null)
            {
                throw new PluginApplicationException($"Process status is null in API response for process_id: {processId}");
            }
            if (processStatus.Process.Type != "async-export")
            {
                throw new PluginApplicationException(
                    $"Expected 'async-export' process, but got '{processStatus.Process.Type}' for process_id: {processId}");
            }
        }

        if (processStatus.Process.Status != "finished")
        {
            throw new PluginApplicationException(
                $"Translated file export process failed with status: {processStatus.Process.Status}, " +
                $"message: {processStatus.Process.Message ?? "No message provided"} for process_id: {processId}");
        }

        var downloadUrl = processStatus.Process.Details.DownloadUrl;
        if (string.IsNullOrEmpty(downloadUrl))
        {
            throw new PluginApplicationException(
                $"Download URL is null or empty in finished process response for process_id: {processId}");
        }

        var fileUri = new Uri(downloadUrl);
        var zipResponse = await Client.ExecuteWithHandling(new RestRequest(fileUri));

        var rawBytes = zipResponse.RawBytes
            ?? throw new PluginApplicationException("Downloaded file content is null.");

        await using var zipStream = new MemoryStream(rawBytes);
        using var sourceArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: false);

        var languageDirName = input.LanguageCode.Replace("-", "_");
        var matchingEntry = sourceArchive.Entries.FirstOrDefault(en =>
            !en.FullName.EndsWith('/') &&
            en.FullName.Split('/').First() == languageDirName &&
            en.Name == input.FileName);

        if (matchingEntry == null)
        {
            throw new InvalidOperationException(
                $"File '{input.FileName}' for language '{input.LanguageCode}' not found in the archive.");
        }

        using var entryStream = matchingEntry.Open();
        using var bufferedStream = new MemoryStream();
        await entryStream.CopyToAsync(bufferedStream);
        bufferedStream.Position = 0;

        var uploadedFile = await fileManagementClient.UploadAsync(
            bufferedStream,
            contentType: "application/octet-stream",
            fileName: input.FileName
        );

        return new DownloadProjectFilesAsZipResponse
        {
            File = uploadedFile
        };
    }

    [Action("Download XLIFF file", Description = "Download XLIFF file")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadXLIFF([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadXLIFFFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new DownloadFileRequest
            {
                Format = "offline_xliff",
                AllPlatforms = input.AllPlatforms ?? true,
                FilterTaskId = input.FilterTaskId
            });

        var exportResult = await Client.ExecuteWithHandling<ExportFilesDto>(request);
        var fileUri = new Uri(exportResult.BundleUrl);
        var zipResponse = await Client.ExecuteWithHandling(new(fileUri));

        var rawBytes = zipResponse.RawBytes!;
        await using var zipStream = new MemoryStream(rawBytes);

        using var sourceArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: false);

        var expectedFileName = $"{input.LanguageCode.Replace("_", "-")}.xliff";
        var matchingEntry = sourceArchive.Entries.FirstOrDefault(en =>
            !en.FullName.EndsWith('/') &&
            en.Name == expectedFileName);

        await using var entryStream = matchingEntry.Open();

        var uploadedFile = await fileManagementClient.UploadAsync(
            entryStream,
            contentType: "application/xliff+xml",
            fileName: expectedFileName
        );

        return new DownloadProjectFilesAsZipResponse
        {
            File = uploadedFile
        };
    }

    [Action("Download XLIFF files from task", Description = "Download XLIFF files from task")]
    public async Task<DownloadFilesResponse> DownloadXLIFFFromTask([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTaskXLIFFFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new DownloadFileRequest
            {
                Format = "offline_xliff",
                AllPlatforms = input.AllPlatforms ?? true,
                FilterTaskId = input.FilterTaskId
            });

        var exportResult = await Client.ExecuteWithHandling<ExportFilesDto>(request);
        var fileUri = new Uri(exportResult.BundleUrl);
        var zipResponse = await Client.ExecuteWithHandling(new(fileUri));

        var rawBytes = zipResponse.RawBytes!;
        await using var zipStream = new MemoryStream(rawBytes);

        using var sourceArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: false);

        var result = new List<FileReference>();
        foreach (var entry in sourceArchive.Entries.Where(en =>
            !en.FullName.EndsWith('/') &&
            en.Name.EndsWith(".xliff")))
        {
            await using var entryStream = entry.Open();

            var tempStream = new MemoryStream();
            await entryStream.CopyToAsync(tempStream);
            tempStream.Position = 0;

            if (tempStream.Length == 0)
                continue; 

            var uploadedFile = await fileManagementClient.UploadAsync(
                tempStream,
                contentType: "application/xliff+xml",
                fileName: entry.Name
            );


            result.Add(uploadedFile);
        }

        return new DownloadFilesResponse(result.ToArray());
    }

    [Action("Download all XLIFF files from project", Description = "Download all XLIFF files from project")]
    public async Task<DownloadFilesResponse> DownloadXLIFFAll([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadAllXLIFFFilesRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new DownloadFileRequest
            {
                Format = "offline_xliff",
                AllPlatforms = input.AllPlatforms ?? true
            });

        var exportResult = await Client.ExecuteWithHandling<ExportFilesDto>(request);
        var fileUri = new Uri(exportResult.BundleUrl);
        var zipResponse = await Client.ExecuteWithHandling(new(fileUri));

        var rawBytes = zipResponse.RawBytes!;
        await using var zipStream = new MemoryStream(rawBytes);

        using var sourceArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen: false);

        var result = new List<FileReference>();
        foreach (var entry in sourceArchive.Entries.Where(en =>
            !en.FullName.EndsWith('/') &&
            en.Name.EndsWith(".xliff")))
        {
            await using var entryStream = entry.Open();

            var tempStream = new MemoryStream();
            await entryStream.CopyToAsync(tempStream);
            tempStream.Position = 0;

            if (tempStream.Length == 0)
                continue;

            var uploadedFile = await fileManagementClient.UploadAsync(
                tempStream,
                contentType: "application/xliff+xml",
                fileName: entry.Name
            );

            result.Add(uploadedFile);
        }

        return new DownloadFilesResponse(result.ToArray());
    }

    [Action("Delete file", Description = "Delete file from project")]
    public Task DeleteFile([ActionParameter] DeleteFileRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/files/{input.FileId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    [Action("Export glossary", Description = "Export project glossary as TBX file")]
    public async Task<FileReference> ExportGlossaryTerms([ActionParameter] ProjectRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/glossary-terms";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithHandling<GlossaryTermsResponse>(request);

        var terms = response.Data;

        if (terms == null || !terms.Any())
            throw new PluginApplicationException($"No glossary terms found for project ID: {input.ProjectId}");

        var conceptEntries = terms.Select(t =>
        {
            var sections = new List<GlossaryLanguageSection>
                {
                    new GlossaryLanguageSection("en", new List<GlossaryTermSection>
                    {
                        new GlossaryTermSection(t.Term)
                        {
                            TermNotes = new Dictionary<string, string>
                            {
                                ["description"] = t.Description
                            }
                        }
                    })
                };

            sections.AddRange(t.Translations
                .Where(tr => !string.IsNullOrWhiteSpace(tr.Translation))
                .Select(tr => new GlossaryLanguageSection(tr.LangIso, new List<GlossaryTermSection>
                {
                        new GlossaryTermSection(tr.Translation)
                        {
                            TermNotes = new Dictionary<string, string>
                            {
                                ["description"] = tr.Description
                            }
                        }
                }))
            );

            var entry = new GlossaryConceptEntry(t.Id.ToString(), sections)
            {
                Definition = t.Description,
                Domain = t.Tags != null && t.Tags.Any()
                               ? string.Join(",", t.Tags)
                               : null
            };

            return entry;
        }).ToList();

        var glossary = new Glossary(conceptEntries)
        {
            Title = $"Project_{input.ProjectId}_Glossary",
            SourceDescription = $"Exported from project {input.ProjectId}"
        };

        using var tbxStream = glossary.ConvertToTbx();

        var fileReference = await fileManagementClient.UploadAsync(
            tbxStream,
            "application/x-tbx+xml",
            $"project_{input.ProjectId}_glossary.tbx"
        );

        return fileReference;
    }

    [Action("Import glossary", Description = "Import glossary terms from a TBX file into the project")]
    public async Task<ImportGlossaryResponse> ImportGlossary(
             [ActionParameter] ProjectRequest input,
             [ActionParameter] FileReference tbxFile)
    {
        await using var originalStream = await fileManagementClient.DownloadAsync(tbxFile);
        var xDoc = XDocument.Load(originalStream);
        var root = xDoc.Root;
        if (root == null || !string.Equals(root.Name.LocalName, "tbx", StringComparison.OrdinalIgnoreCase))
            throw new PluginApplicationException("The provided file is not a valid TBX document.");

        XNamespace ns = root.Name.Namespace;

        var entries = root
            .Element(ns + "text")?
            .Element(ns + "body")?
            .Elements(ns + "conceptEntry");

        if (entries == null || !entries.Any())
            throw new PluginApplicationException("No <conceptEntry> elements found in TBX file.");

        var termsPayload = new List<object>();

        foreach (var entry in entries)
        {
            var definition = entry
                .Elements(ns + "descrip")
                .FirstOrDefault(d => (string)d.Attribute("type") == "definition")
                ?.Value ?? string.Empty;

            var langSecs = entry.Elements(ns + "langSec");

            var primarySec = langSecs.First();
            var baseLangIso = (string)primarySec.Attribute(XNamespace.Xml + "lang") ?? string.Empty;
            var baseTerm = primarySec
                .Element(ns + "termSec")
                ?.Element(ns + "term")
                ?.Value ?? string.Empty;
            var baseTermNote = primarySec
                .Element(ns + "termSec")
                ?.Element(ns + "termNote")
                ?.Value ?? string.Empty;

            var translations = langSecs
                .Skip(1)
                .Select(sec => new
                {
                    langIso = (string)sec.Attribute(XNamespace.Xml + "lang") ?? string.Empty,
                    translation = sec
                        .Element(ns + "termSec")
                        ?.Element(ns + "term")
                        ?.Value ?? string.Empty,
                    description = sec
                        .Element(ns + "termSec")
                        ?.Element(ns + "termNote")
                        ?.Value ?? string.Empty
                })
                .ToList();

            termsPayload.Add(new
            {
                term = baseTerm,
                description = baseTermNote,
                caseSensitive = false,
                translatable = true,
                forbidden = false,
                translations = translations.Select(tr => new
                {
                    lang_iso = tr.langIso,
                    translation = tr.translation,
                    description = tr.description
                }),
                tags = Array.Empty<string>()
            });
        }

        var endpoint = $"/projects/{input.ProjectId}/glossary-terms";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds);
        request.AddJsonBody(new { terms = termsPayload });

        var response = await Client.ExecuteWithHandling<ImportGlossaryResponse>(request);
        return response;
    }

    #endregion

    private async Task<FileReference> ConvertMqXliffToXliff(Stream stream, string fileName, bool useSkeleton = false)
    {
        var xliffFile = stream.ConvertMqXliffToXliff(useSkeleton);
        stream.Position = 0;
        var xliffStream = new MemoryStream();
        xliffFile.Save(xliffStream);
        
        xliffStream.Position = 0;
        fileName = ParseFileName(fileName);
        string contentType = MediaTypeNames.Text.Xml;
        return await fileManagementClient.UploadAsync(xliffStream, contentType, fileName);
    } 
    
    private string ParseFileName(string fileName)
    {
        if(fileName.EndsWith(".mqxliff"))
        {
            if (fileName.Contains(".xliff"))
            {
                return fileName.Replace(".mqxliff", String.Empty);
            }
            else
            {
                return fileName.Replace(".mqxliff", ".xliff");
            }
        }
        
        return fileName;
    }
}