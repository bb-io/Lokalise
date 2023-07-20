using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Languages;
using Apps.Lokalise.Models.Responses.Languages;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Actions
{
    [ActionList]
    public class LanguageActions
    {
        #region Fields

        private readonly LokaliseClient _client;

        #endregion

        #region Constructors

        public LanguageActions()
        {
            _client = new();
        }

        #endregion

        #region Actions

        [Action("List all system languages", Description = "List all system languages")]
        public Task<ListLanguagesResponse> ListSystemLanguages(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
            => ListLanguages(authenticationCredentialsProviders, "/system/languages");

        [Action("List all project languages", Description = "List all project languages")]
        public Task<ListLanguagesResponse> ListProjectLanguages(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] [Display("Project ID")] string projectId)
            => ListLanguages(authenticationCredentialsProviders, $"/projects/{projectId}/languages");

        [Action("Add language to project", Description = "Add language to project")]
        public Task AddLanguageToProject(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] [Display("Project ID")]
            string projectId,
            [ActionParameter] AddLanguageToProjectInput input)
        {
            var request = new LokaliseRequest(
                    $"/projects/{projectId}/languages",
                    Method.Post,
                    authenticationCredentialsProviders)
                .WithJsonBody(new AddLanguageToProjectRequest(input));

            return _client.ExecuteWithHandling(request);
        }

        [Action("Delete language from project", Description = "Delete language from project")]
        public Task DeleteLanguageFromProject(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DeleteLanguageFromProjectRequest input)
        {
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/languages/{input.LanguageId}",
                Method.Delete, authenticationCredentialsProviders);

            return _client.ExecuteWithHandling(request);
        }

        #endregion

        #region Utils

        private async Task<ListLanguagesResponse> ListLanguages(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            string endpoint)
        {
            var items = await Paginator.GetAll<LanguagesWrapper, LanguageDto>(
                authenticationCredentialsProviders.ToArray(),
                endpoint);

            return new(items);
        }

        #endregion
    }
}