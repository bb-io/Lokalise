using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Files;
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
    public class LanguageActions
    {
        [Action("List all system languages", Description = "List all system languages")]
        public ListLanguagesResponse ListSystemLanguages(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/system/languages", Method.Get, authenticationCredentialsProviders);
            var result = client.Get<ListLanguagesResponse>(request);
            return result;
        }

        [Action("List all project languages", Description = "List all project languages")]
        public ListLanguagesResponse ListProjectLanguages(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, 
            [ActionParameter] ListProjectLanguagesRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/languages", Method.Get, authenticationCredentialsProviders);
            var result = client.Get<ListLanguagesResponse>(request);
            return result;
        }

        [Action("Add language to project", Description = "Add language to project")]
        public void AddLanguageToProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] AddLanguageToProjectRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/languages", Method.Post, authenticationCredentialsProviders);
            request.AddJsonBody(new
            {
                languages = new[]
                {
                    new
                    {
                        lang_iso = input.LanguageCode
                    }
                }
            });
            client.Execute(request);
        }

        [Action("Delete language from project", Description = "Delete language from project")]
        public void DeleteLanguageFromProject(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DeleteLanguageFromProjectRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/languages/{input.LanguageId}", Method.Delete, authenticationCredentialsProviders);
            client.Execute(request);
        }
    }
}
