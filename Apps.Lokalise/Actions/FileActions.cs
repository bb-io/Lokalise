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

namespace Apps.Lokalise.Actions
{
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

        [Action("Download all project files", Description = "Download all project files as zip archive")]
        public async Task<DownloadProjectFilesResponse> DownloadProjectFiles(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ProjectRequest project,
            [ActionParameter] DownloadFileRequest input)
        {
            var endpoint = $"/projects/{project.ProjectId}/files/download";
            var request = new LokaliseRequest(endpoint, Method.Post, authenticationCredentialsProviders)
                .WithJsonBody(input);

            var exportResult = await _client.ExecuteWithHandling<ExportFilesDto>(request);

            var fileUri = new Uri(exportResult.BundleUrl);
            var dataResponse = await _client.ExecuteWithHandling(new(fileUri));

            return new()
            {
                File = new(dataResponse.RawBytes!)
                {
                    Name = fileUri.Segments.Last(),
                    ContentType = dataResponse.Headers?
                        .FirstOrDefault(x => x.Name == "Content-Type")?.Value?.ToString() ?? string.Empty
                }
            };
        }

        [Action("Download translated project file", Description = "Download translated project file by name")]
        public async Task<DownloadProjectFilesResponse> DownloadTranslatedFile(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ProjectRequest project,
            [ActionParameter] DownloadTranslatedFileRequest input)
        {
            var allFiles = await DownloadProjectFiles(
                authenticationCredentialsProviders,
                project,
                input);

            var fileData = await allFiles.File.Bytes.GetFileFromZip(en =>
                en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") &&
                en.Name == input.FileName);

            return new()
            {
                File = fileData
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
}