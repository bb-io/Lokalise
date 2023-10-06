using System.IO.Compression;
using System.Net.Mime;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Files;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using Apps.Lokalise.Models.Requests.Files;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Utils.Extensions.Files;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;

namespace Apps.Lokalise.Actions;

[ActionList]
public class FileActions
{
    #region Fields

    private readonly LokaliseClient _client;

    #endregion

    #region Constructors

    public FileActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("List all project files", Description = "List all project files")]
    public async Task<ListAllFilesResponse> ListAllFiles(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ListAllFilesRequest input)
    {
        var endpoint =
            $"/projects/{input.ProjectId}/files?filter_filename={input.FilterFileName}";

        var items = await Paginator.GetAll<FilesWrapper, FileInfoDto>(
            authenticationCredentialsProviders.ToArray(),
            endpoint);

        return new(items);
    }

    [Action("Upload file to project", Description = "Upload file to project")]
    public async Task<QueuedProcessDto> UploadFile(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest project,
        [ActionParameter] UploadFileInput input)
    {
        var creds = authenticationCredentialsProviders.ToArray();
        var endpoint = $"/projects/{project.ProjectId}/files/upload";

        var request = new LokaliseRequest(endpoint, Method.Post, creds).WithJsonBody(new UploadFileRequest(input));
        var uploadResult = await _client.ExecuteWithHandling<QueuedProcessDto>(request);

        return await _client
            .PollFileImportOperation(project.ProjectId, uploadResult.Process.ProcessId, creds);
    }

    [Action("Download all project files as ZIP", Description = "Download all project files as ZIP archive")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadProjectFilesAsZip(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadFileRequest input)
    {
        var endpoint = $"/projects/{project.ProjectId}/files/download";
        var request = new LokaliseRequest(endpoint, Method.Post, authenticationCredentialsProviders)
            .WithJsonBody(input);

        var exportResult = await _client.ExecuteWithHandling<ExportFilesDto>(request);

        var fileUri = new Uri(exportResult.BundleUrl);
        var zipResponse = await _client.ExecuteWithHandling(new(fileUri));

        await using var zipStream = new MemoryStream();
        var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Create, false);

        var files = await zipResponse.RawBytes!.GetFilesFromZip();

        var createZipTasks = files
            .Where(x => input.FilterLangs is null || input.FilterLangs.Any(y => x.Path.StartsWith(y)))
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
        IEnumerable<AuthenticationCredentialsProvider> creds,
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadSourceFilesRequest input)
    {
        var projectData = await new ProjectActions().RetrieveProject(creds, project);
        var archive = await DownloadProjectFilesAsZip(creds, project, new()
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
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTranslatedFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(
            authenticationCredentialsProviders,
            project,
            input);

        var fileData = await allFiles.File.Bytes.GetFileFromZip(en =>
            en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") &&
            en.Name == input.FileName);

        return new()
        {
            File = fileData.File
        };
    }

    [Action("Delete file", Description = "Delete file from project")]
    public Task DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] DeleteFileRequest input)
    {
        var request = new LokaliseRequest(
            $"/projects/{input.ProjectId}/files/{input.FileId}",
            Method.Delete,
            authenticationCredentialsProviders);

        return _client.ExecuteWithHandling(request);
    }

    #endregion
}