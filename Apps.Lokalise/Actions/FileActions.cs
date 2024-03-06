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

namespace Apps.Lokalise.Actions;

[ActionList]
public class FileActions : LokaliseInvocable
{
    private readonly IFileManagementClient _fileManagementClient; 
    private readonly RestClient _restClient = new("https://webhook.site/59fb42da-de39-4e7b-8b9c-12a186000b16");
    
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
        RestRequest uploadFileRequest = new(string.Empty, Method.Post);
        await _restClient.ExecuteAsync(uploadFileRequest.WithJsonBody(new { Status = "Upload file", File = input.File.Name }));
        
        var endpoint = $"/projects/{project.ProjectId}/files/upload";
        var request =
            new LokaliseRequest(endpoint, Method.Post, Creds).WithJsonBody(
                new UploadFileRequest(input, _fileManagementClient));
        var uploadResult = await Client.ExecuteWithHandling<QueuedProcessDto>(request);
        
        RestRequest fileImportRequest = new(String.Empty, Method.Post);
        await _restClient.ExecuteAsync(fileImportRequest.WithJsonBody(new { Status = "File import", StatusUploadResult = uploadResult.Process.Status }));

        return await Client
            .PollFileImportOperation(project.ProjectId, uploadResult.Process.ProcessId, Creds);
    }
    
    [Action("Upload file to project as XLIFF", Description = "Upload file to project as XLIFF")]
    public async Task<QueuedProcessDto> UploadFileAsXliff([ActionParameter] ProjectRequest project,
        [ActionParameter] UploadFileInput input)
    {
        RestRequest startedRequest = new(string.Empty, Method.Post);
        await _restClient.ExecuteAsync(startedRequest.WithJsonBody(new { Status = "Started", File = input.File.Name }));
        
        if(input.File.Name.EndsWith(".mqxliff"))
        {
            var fileReference = await ConvertMqXliffToXliff(input.File);
            RestRequest fileGeneratedRequest = new(string.Empty, Method.Post);
            await _restClient.ExecuteAsync(fileGeneratedRequest.WithJsonBody(new { Status = "File generated", File = fileReference.Name, Url = fileReference.Url }));
            
            input.File = fileReference;
            return await UploadFile(project, input);
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
        var filteredFiles = files
            .Where(file => input.FilterLangs is null || input.FilterLangs.Any(lang =>
                file.Path.StartsWith(lang) || file.File.Name.StartsWith($"{lang}.")));

        foreach (var file in filteredFiles)
        {
            await using var fileStream = await _fileManagementClient.DownloadAsync(file.File);
            var fileBytes = await fileStream.GetByteData();
            await zipArchive.AddFileToZip(file.Path, fileBytes);
        }
        
        zipArchive.Dispose();
        
        zipStream.Position = 0;

        var zipFileReference = await _fileManagementClient.UploadAsync(zipStream,
            contentType: zipResponse.ContentType ?? MediaTypeNames.Application.Octet,
            fileName: fileUri.Segments.Last());

        return new() { File = zipFileReference };
    }

    [Action("Download project source files", Description = "Download all project source files")]
    public async Task<DownloadFilesResponse> DownloadProjectSourceFiles(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadSourceFilesRequest input)
    {
        var projectData = await new ProjectActions(InvocationContext).RetrieveProject(project);
        var archive = await DownloadProjectFilesAsZip(project, new()
        {
            Format = input.Format
        });

        var archiveStream = await _fileManagementClient.DownloadAsync(archive.File);
        var archiveBytes = await archiveStream.GetByteData();
        
        var files = await archiveBytes.GetFilesFromZip(_fileManagementClient);

        var sourceFiles = files
            .Where(file => file.File.Size > 0 && file.Path.StartsWith(projectData.BaseLanguageIso))
            .Select(file => file.File)
            .ToArray();

        return new(sourceFiles);
    }

    [Action("Download translated project file", Description = "Download translated project file by name")]
    public async Task<DownloadProjectFilesAsZipResponse> DownloadTranslatedFile(
        [ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTranslatedFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, input);
        var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
        var allFilesBytes = await allFilesStream.GetByteData();

        var fileData = await allFilesBytes.GetFileFromZip(
            en => en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") && en.Name == input.FileName,
            _fileManagementClient);

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
        var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
        var allFilesBytes = await allFilesStream.GetByteData();

        var fileData = await allFilesBytes
            .GetFileFromZip(en => en.Name == $"{input.LanguageCode.Replace("_", "-")}.xliff", _fileManagementClient);

        return new()
        {
            File = fileData.File
        };
    }

    [Action("Download XLIFF files from task", Description = "Download XLIFF files from task")]
    public async Task<DownloadFilesResponse> DownloadXLIFFFromTask([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadTaskXLIFFFileRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, new(input)
        {
            Format = "offline_xliff",
            AllPlatforms = input.AllPlatforms ?? true,
            FilterTaskId = input.FilterTaskId
        });
        var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
        var allFilesBytes = await allFilesStream.GetByteData();
        var files = await allFilesBytes.GetFilesFromZip(_fileManagementClient);
        return new(files.Where(file => file.File.Size > 0).Select(file => file.File));
    }

    [Action("Download all XLIFF files from project", Description = "Download all XLIFF files from project")]
    public async Task<DownloadFilesResponse> DownloadXLIFFAll([ActionParameter] ProjectRequest project,
        [ActionParameter] DownloadAllXLIFFFilesRequest input)
    {
        var allFiles = await DownloadProjectFilesAsZip(project, new(input)
        {
            Format = "offline_xliff",
            AllPlatforms = input.AllPlatforms ?? true
        });
        var allFilesStream = await _fileManagementClient.DownloadAsync(allFiles.File);
        var allFilesBytes = await allFilesStream.GetByteData();
        var files = await allFilesBytes.GetFilesFromZip(_fileManagementClient);
        return new(files.Where(file => file.File.Size > 0).Select(file => file.File));
    }

    [Action("Delete file", Description = "Delete file from project")]
    public Task DeleteFile([ActionParameter] DeleteFileRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/files/{input.FileId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    #endregion
    
    private async Task<FileReference> ConvertMqXliffToXliff(FileReference file, bool useSkeleton = false)
    {
        var stream = await _fileManagementClient.DownloadAsync(file);
        
        RestRequest fileGeneratedRequest = new(String.Empty, Method.Post);
        await _restClient.ExecuteAsync(fileGeneratedRequest.WithJsonBody(new { Status = "File downloaded from ConvertMqXliffToXliff", File = file.Name }));
        
        var xliffFile = stream.ConvertMqXliffToXliff(useSkeleton);
        
        RestRequest fileConvertedRequest = new(String.Empty, Method.Post);
        await _restClient.ExecuteAsync(fileConvertedRequest.WithJsonBody(new { Status = "File converted from ConvertMqXliffToXliff" }));
        
        var xliffStream = new MemoryStream();
        xliffFile.Save(xliffStream);
        
        xliffStream.Position = 0;
        string fileName = file.Name.Replace(".mqxliff", ".xliff");
        string contentType = MediaTypeNames.Text.Xml;
        return await _fileManagementClient.UploadAsync(xliffStream, contentType, fileName);
    } 
}