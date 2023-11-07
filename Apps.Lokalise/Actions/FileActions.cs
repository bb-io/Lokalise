using System.IO.Compression;
using System.Net.Mime;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using RestSharp;
using Apps.Lokalise.Models.Requests.Files;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;

namespace Apps.Lokalise.Actions;

[ActionList]
public class FileActions : LokaliseInvocable
{
    public FileActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List all project files", Description = "List all project files")]
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

        var request = new LokaliseRequest(endpoint, Method.Post, Creds).WithJsonBody(new UploadFileRequest(input));
        var uploadResult = await Client.ExecuteWithHandling<QueuedProcessDto>(request);

        return await Client
            .PollFileImportOperation(project.ProjectId, uploadResult.Process.ProcessId, Creds);
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
        var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, false);

        var files = await zipResponse.RawBytes!.GetFilesFromZip();

        var createZipTasks = files
            .Where(x => input.FilterLangs is null ||
                        input.FilterLangs.Any(y => x.Path.StartsWith(y) || x.File.Name.StartsWith($"{y}.")))
            .Select(x => zipArchive.AddFileToZip(x.Path, x.File.Bytes));

        await Task.WhenAll(createZipTasks);
        zipArchive.Dispose();

        return new()
        {
            File = new(zipStream.ToArray())
            {
                Name = fileUri.Segments.Last(),
                ContentType = zipResponse.ContentType ?? MediaTypeNames.Application.Octet
            }
        };
    }

    [Action("Download project source files", Description = "Download all project source files")]
    public async Task<DownloadSourceFilesResponse> DownloadProjectSourceFiles(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadSourceFilesRequest input)
    {
        var projectData = await new ProjectActions(InvocationContext).RetrieveProject(project);
        var archive = await DownloadProjectFilesAsZip(project, new()
        {
            Format = input.Format
        });

        var files = await archive.File.Bytes.GetFilesFromZip();

        var sourceFiles = files
            .Where(x => x.Path.StartsWith(projectData.BaseLanguageIso) && x.File.Bytes.Any())
            .Select(x => x.File)
            .ToArray();

        return new(sourceFiles);
    }

    [Action("Download translated project file", Description = "Download translated project file by name")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadTranslatedFile(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTranslatedFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, input);

        var fileData = await allFiles.File.Bytes.GetFileFromZip(en =>
            en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") &&
            en.Name == input.FileName);

        return new()
        {
            File = fileData.File
        };
    }

    [Action("Download XLIFF file", Description = "Download XLIFF file")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadXLIFF([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadXLIFFFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, new(input)
        {
            Format = "offline_xliff",
            AllPlatforms = input.AllPlatforms ?? true,
            FilterTaskId = input.FilterTaskId
        });

        var fileData = await allFiles.File.Bytes
            .GetFileFromZip(en => en.Name == $"{input.LanguageCode.Replace("_", "-")}.xliff");

        return new()
        {
            File = fileData.File
        };
    }

    [Action("Download XLIFF files from task", Description = "Download XLIFF files from task")]
    public async Task<DownloadXLIFFAllResponse> DownloadXLIFFFromTask([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTaskXLIFFFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, new(input)
        {
            Format = "offline_xliff",
            AllPlatforms = input.AllPlatforms ?? true,
            FilterTaskId = input.FilterTaskId
        });

        var files = await allFiles.File.Bytes.GetFilesFromZip();

        return new()
        {
            Files = files.Where(f => f.File.Bytes.Length > 0).Select(f => f.File).ToList()
        };
    }

    [Action("Download all XLIFF files from project", Description = "Download all XLIFF files from project")]
    public async Task<DownloadXLIFFAllResponse> DownloadXLIFFAll([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadAllXLIFFFilesRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, new(input)
        {
            Format = "offline_xliff",
            AllPlatforms = input.AllPlatforms ?? true
        });

        var files = await allFiles.File.Bytes.GetFilesFromZip();

        return new()
        {
            Files = files.Where(f => f.File.Bytes.Length > 0).Select(f => f.File).ToList()
        };
    }

    [Action("Delete file", Description = "Delete file from project")]
    public Task DeleteFile([ActionParameter] DeleteFileRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/files/{input.FileId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    #endregion
}