using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Languages;
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
                        key_name = input.KeyName
                    }
                }
            });
            return client.Get<ListProjectKeysResponse>(request).Keys.First();
        }
    }
}
