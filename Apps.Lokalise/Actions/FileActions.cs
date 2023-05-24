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
            ListAllFilesRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/files", Method.Get, authenticationCredentialsProviders);
            var result = client.Get<FilesWrapper>(request);
            return new ListAllFilesResponse()
            {
                Files = result.Files
            };
        }
    }
}
