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
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Xliff.Utils.Extensions;
using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Apps.Lokalise.Models.Responses.Glossary;
using Blackbird.Applications.Sdk.Glossaries.Utils.Dtos;
using Blackbird.Applications.Sdk.Glossaries.Utils.Converters;
using Blackbird.Applications.Sdk.Utils.Models;
using System.Xml.Linq;
using Apps.Lokalise.Utils.Zip;

namespace Apps.Lokalise.Actions;

[ActionList]
public class FileActions : LokaliseInvocable
{
    private readonly IFileManagementClient _fileManagementClient; 
    
    public FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) 
        : base(invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

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
                new UploadFileRequest(input, _fileManagementClient));
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
            var stream = await _fileManagementClient.DownloadAsync(input.File);
            var fileReference = await ConvertMqXliffToXliff(stream, input.File.Name);
            input.File = fileReference;
            return await UploadFile(project, input);
        }

        if (input.OverwriteExistingKeys.HasValue && input.OverwriteExistingKeys.Value)
        {
            var fileStream = await _fileManagementClient.DownloadAsync(input.File);
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
            input.File = await _fileManagementClient.UploadAsync(xliffStream, MediaTypeNames.Text.Xml, input.File.Name);
        }
        
        return await UploadFile(project, input);
    }

    [Action("Download all project files as ZIP", Description = "Download all project files as ZIP archive")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadProjectFilesAsZip(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/download";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(input);

        var exportResult = await Client.ExecuteWithHandling<ExportFilesDto>(request);
        var fileUri = new Uri(exportResult.BundleUrl);
        var zipResponse = await Client.ExecuteWithHandling(new(fileUri));

        await using var zipStream = new MemoryStream();
        var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, true);

        var files = await zipResponse.RawBytes!.GetFilesFromZip(_fileManagementClient);


        //var filteredFiles = files
        //    .Where(file => input.FilterLangs is null || input.FilterLangs.Any(lang =>
        //        file.Path.StartsWith(lang) || file.File.Name.Contains($"{lang}.")));

        foreach (var file in files.Where(x => !x.Path.EndsWith('/')))
        {
            await using var fileStream = await _fileManagementClient.DownloadAsync(file.File);
            var fileBytes = await fileStream.GetByteData();
            using var fileDataStream = new MemoryStream(fileBytes);
            await zipArchive.AddFileToZip(file.Path, fileDataStream);
        }

        zipArchive.Dispose();

        zipStream.Position = 0;

        var zipFileReference = await _fileManagementClient.UploadAsync(zipStream,
            contentType: zipResponse.ContentType ?? MediaTypeNames.Application.Octet,
            fileName: fileUri.Segments.Last());

        return new() { File = zipFileReference };
    }

    //[Action("Download project source files", Description = "Download all project source files")]
    //public async Task<DownloadFilesResponse> DownloadProjectSourceFiles(
    //    [ActionParameter] ProjectRequest project,
    //    [ActionParameter] DownloadSourceFilesRequest input)
    //{
    //    var projectData = await new ProjectActions(InvocationContext).RetrieveProject(project);
    //    var archive = await DownloadProjectFilesAsZip(project, new()
    //    {
    //        Format = input.Format
    //    });

    //    var archiveStream = await _fileManagementClient.DownloadAsync(archive.File);
    //    var archiveBytes = await archiveStream.GetByteData();

    //    var files = await archiveBytes.GetFilesFromZip(_fileManagementClient);

    //    var sourceFiles = files
    //        .Where(file => file.File.Size > 0 && file.Path.StartsWith(projectData.BaseLanguageIso))
    //        .Select(file => file.File)
    //        .ToArray();

    //    return new(sourceFiles);
    //}

    //[Action("Download translated project file", Description = "Download translated project file by name")]
    //public async Task<DownloadProjectFilesAsZipResponse> DownloadTranslatedFile(
    //    [ActionParameter] ProjectRequest project,
    //    [ActionParameter] DownloadTranslatedFileRequest input)
    //{
    //    var allFiles = await DownloadProjectFilesAsZip(project, input);
    //    var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
    //    var allFilesBytes = await allFilesStream.GetByteData();

    //    var fileData = await allFilesBytes.GetFileFromZip(
    //        en => en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") && en.Name == input.FileName,
    //        _fileManagementClient);

    //    return new()
    //    {
    //        File = fileData.File
    //    };
    //}

    //[Action("Download XLIFF file", Description = "Download XLIFF file")]
    //public async Task<DownloadProjectFilesAsZipResponse> DownloadXLIFF([ActionParameter] ProjectRequest project,
    //    [ActionParameter] DownloadXLIFFFileRequest input)
    //{
    //    var allFiles = await DownloadProjectFilesAsZip(project, new(input)
    //    {
    //        Format = "offline_xliff",
    //        AllPlatforms = input.AllPlatforms ?? true,
    //        FilterTaskId = input.FilterTaskId
    //    });
    //    var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
    //    var allFilesBytes = await allFilesStream.GetByteData();

    //    var fileData = await allFilesBytes
    //        .GetFileFromZip(en => en.Name == $"{input.LanguageCode.Replace("_", "-")}.xliff", _fileManagementClient);

    //    return new()
    //    {
    //        File = fileData.File
    //    };
    //}

    //[Action("Download XLIFF files from task", Description = "Download XLIFF files from task")]
    //public async Task<DownloadFilesResponse> DownloadXLIFFFromTask([ActionParameter] ProjectRequest project,
    //    [ActionParameter] DownloadTaskXLIFFFileRequest input)
    //{
    //    var allFiles = await DownloadProjectFilesAsZip(project, new(input)
    //    {
    //        Format = "offline_xliff",
    //        AllPlatforms = input.AllPlatforms ?? true,
    //        FilterTaskId = input.FilterTaskId
    //    });
    //    var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
    //    var allFilesBytes = await allFilesStream.GetByteData();
    //    var files = await allFilesBytes.GetFilesFromZip(_fileManagementClient);
    //    return new(files.Where(file => file.File.Size > 0).Select(file => file.File));
    //}

    //[Action("Download all XLIFF files from project", Description = "Download all XLIFF files from project")]
    //public async Task<DownloadFilesResponse> DownloadXLIFFAll([ActionParameter] ProjectRequest project,
    //    [ActionParameter] DownloadAllXLIFFFilesRequest input)
    //{
    //    var allFiles = await DownloadProjectFilesAsZip(project, new(input)
    //    {
    //        Format = "offline_xliff",
    //        AllPlatforms = input.AllPlatforms ?? true
    //    });
    //    var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
    //    var allFilesBytes = await allFilesStream.GetByteData();
    //    var files = await allFilesBytes.GetFilesFromZip(_fileManagementClient);
    //    return new(files.Where(file => file.File.Size > 0).Select(file => file.File));
    //}

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

        var fileReference = await _fileManagementClient.UploadAsync(
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
        await using var originalStream = await _fileManagementClient.DownloadAsync(tbxFile);
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
        return await _fileManagementClient.UploadAsync(xliffStream, contentType, fileName);
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