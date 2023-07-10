using Apps.Lokalise.Dtos;
using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Files;
using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Actions
{
    [ActionList]
    public class FileActions
    {
        [Action("List all project files", Description = "List all project files")]
        public ListAllFilesResponse? ListAllFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ListAllFilesRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/files", Method.Get, authenticationCredentialsProviders);
            request.AddQueryParameter("filter_filename", input.FileNameFilter);
            var result = client.Get<FilesWrapper>(request);
            return new ListAllFilesResponse()
            {
                Files = result.Files
            };
        }

        [Action("Upload file to project", Description = "Upload file to project")]
        public void UploadFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] UploadFileRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/files/upload", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new
            {
                data = Convert.ToBase64String(input.File),
                filename = input.FileName,
                lang_iso = input.LanguageCode,
                convert_placeholders= input.ConvertPlaceholders,
                detect_icu_plurals= input.DetectIcuPlurals,
                tags= input.Tags,
                tag_inserted_keys= input.TagInsertedKeys,
                tag_updated_keys= input.TagUpdatedKeys,
                tag_skipped_keys= input.TagSkippedKeys,
                replace_modified= input.ReplaceModified,
                slashn_to_linebreak= input.ReplaceSlashN,
                keys_to_values=input.KeyToValues,
                distinguish_by_file= input.DistinguishByFile,
                apply_tm= input.ApplyTm,
                use_automations= input.UseAutomations,
                hidden_from_contributors= input.HiddenFromContributors,
                cleanup_mode= input.CleanupMode,
                custom_translation_status_ids= input.CustomStatusIds,
                custom_translation_status_inserted_keys= input.CustomStatusInsertedKeys,
                custom_translation_status_updated_keys= input.CustomStatusUpdatededKeys,
                custom_translation_status_skipped_keys= input.CustomStatusSkippedKeys,
                skip_detect_lang_iso= input.SkipLanguageDetection,
                format= input.Format,
                filter_task_id= input.FilterTaskId,
            });
            var uploadResult = client.Execute<QueuedProcessDto>(request).Data;
            client.PollFileImportOperation(input.ProjectId, uploadResult.Process.Process_id, authenticationCredentialsProviders);
        }

        [Action("Download all project files", Description = "Download all project files as zip archive")]
        public DownloadProjectFilesResponse DownloadProjectFiles(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DownloadFileRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/files/download", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new
            {
                format = input.FileFormat
            });
            var exportResult = client.Execute<ExportFilesDto>(request).Data;

            var fileUri = new Uri(exportResult.Bundle_url);
            var externalFileClient = new RestClient(fileUri.GetLeftPart(UriPartial.Authority));
            var data = externalFileClient.Get(new RestRequest(fileUri.AbsolutePath, Method.Get)).RawBytes;
            return new DownloadProjectFilesResponse()
            {
                FileName = fileUri.Segments.Last(),
                File = data
            };
        }

        [Action("Download translated project file", Description = "Download translated project file by name")]
        public DownloadProjectFilesResponse DownloadTranslatedFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DownloadTranslatedFileRequest input)
        {
            var allFiles = DownloadProjectFiles(authenticationCredentialsProviders, new DownloadFileRequest() 
            { 
                ProjectId = input.ProjectId,
                FileFormat = input.FileFormat
            });
            byte[] fileData = new byte[0];
            using(var memoryStream = new MemoryStream(allFiles.File))
            {
                using (var zip = new ZipArchive(memoryStream, ZipArchiveMode.Read))
                {
                    var entry = zip.Entries.FirstOrDefault(en => en.FullName.Split('/').First() == input.LanguageCode.Replace("-", "_") && en.Name == input.FileName);
                    using(var resultFileStream = new MemoryStream())
                    {
                        entry.Open().CopyTo(resultFileStream);
                        fileData = resultFileStream.ToArray();
                    }   
                }
            }
            return new DownloadProjectFilesResponse()
            {
                FileName = input.FileName,
                File = fileData
            };
        }

        [Action("Delete file", Description = "Delete file from project")]
        public void DeleteFile(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DeleteFileRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/files/{input.FileId}", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }
    }
}
