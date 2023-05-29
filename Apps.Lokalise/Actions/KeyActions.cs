using Apps.Lokalise.Dtos;
using Apps.Lokalise.ModelConverters;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Languages;
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
    public class KeyActions
    {
        [Action("List all project keys", Description = "List all project keys")]
        public ListProjectKeysResponse ListProjectKeys(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ListProjectKeysRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys", Method.Get, authenticationCredentialsProviders);
            return client.Get<ListProjectKeysResponse>(request);
        }

        [Action("Create key", Description = "Create key in project")]
        public KeyDto CreateKey(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] CreateKeyRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new
            {
                keys = new[]
                {
                    new
                    {
                        key_name = input.KeyName,
                        platforms = new[]{ input.PlatformName }
                    }
                }
            });
            return client.Get<ListProjectKeysResponse>(request).Keys.First();
        }

        [Action("Get key", Description = "Get key by id")]
        public KeyDto? RetrieveKey(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter] RetrieveKeyRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}", Method.Get, authenticationCredentialsProviders);
            return client.Get<KeyDto>(request);
        }

        [Action("Delete key", Description = "Delete key by id")]
        public void DeleteKey(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter] RetrieveKeyRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }
    }
}
