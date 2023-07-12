using Apps.Lokalise.Constants;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using RestSharp;

namespace Apps.Lokalise.Actions
{
    [ActionList]
    public class KeyActions
    {
        #region Fields

        private readonly LokaliseClient _client;

        #endregion

        #region Constructors

        public KeyActions()
        {
            _client = new();
        }

        #endregion

        #region Actions

        [Action("List all project keys", Description = "List all project keys")]
        public async Task<ListProjectKeysResponse> ListProjectKeys(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] [Display("Project id")]
            string projectId,
            [ActionParameter] ListProjectKeysRequest input)
        {
            var baseEndpoint = $"/projects/{projectId}/keys";
            var query = input.AsDictionary()
                .Where(x => !string.IsNullOrEmpty(x.Value))
                .ToDictionary(x => x.Key, x => x.Value.AsLokaliseQuery());

            var endpointWithQuery = QueryHelpers.AddQueryString(baseEndpoint, query);

            var items = await Paginator.GetAll<KeysWrapper, KeyDto>(
                authenticationCredentialsProviders.ToArray(),
                endpointWithQuery);

            return new(items);
        }

        [Action("Create key", Description = "Create key in project")]
        public async Task<Key> CreateKey(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] [Display("Project id")]
            string projectId,
            [ActionParameter] CreateKeyInput input)
        {
            if (input.Platforms.Any(x => !ConstantValues.Platforms.Contains(x)))
                throw new Exception($"Platforms can only contain {String.Join(", ", ConstantValues.Platforms)}");

            var request = new LokaliseRequest($"/projects/{projectId}/keys", Method.Post,
                    authenticationCredentialsProviders)
                .WithJsonBody(new CreateKeyRequest(input));

            var response = await _client.ExecuteWithHandling<ListProjectKeysResponse>(request);
            var key = response.Keys.FirstOrDefault();

            if (key == null)
                throw new Exception("Unknown error occured during key creation");

            return new Key { Id = key.KeyId };
        }

        [Action("Get key", Description = "Get key by id")]
        public async Task<KeyDto> RetrieveKey(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] RetrieveKeyRequest input)
        {
            var endpoint = $"/projects/{input.ProjectId}/keys/{input.KeyId}";

            if (input.DisableReferences is not null)
                endpoint += $"?disable_references={input.DisableReferences.ToString()!.AsLokaliseQuery()}";

            var request = new LokaliseRequest(endpoint, Method.Get, authenticationCredentialsProviders);
            var response = await _client.ExecuteWithHandling<KeyResponse>(request);

            return response.Key;
        }

        [Action("Delete key", Description = "Delete key by id")]
        public Task DeleteKey(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] DeleteKeyRequest input)
        {
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}", Method.Delete,
                authenticationCredentialsProviders);

            return _client.ExecuteWithHandling(request);
        }

        #endregion
    }
}