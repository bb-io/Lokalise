using Apps.Lokalise.Constants;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;
using Blackbird.Applications.Sdk.Utils.Extensions.System;

namespace Apps.Lokalise.Actions;

[ActionList]
public class KeyActions : LokaliseInvocable
{
    public KeyActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("Get project keys", Description = "Get all project keys")]
    public async Task<ListProjectKeysResponse> GetProjectKeys([ActionParameter] ProjectRequest project,
        [ActionParameter] ListProjectKeysRequest input,
        [ActionParameter] ListProjectKeysFilters filters)
    {
        var baseEndpoint = $"/projects/{project.ProjectId}/keys";
        var query = input.AsLokaliseDictionary().AllIsNotNull();

        var endpointWithQuery = baseEndpoint.WithQuery(query);

        var items = await Paginator.GetAll<KeysWrapper, KeyDto>(Creds, endpointWithQuery);

        items = items
            .Where(x => filters.Reviewed is null ||
                        x.Translations?.Any(x =>
                            x.IsReviewed == filters.Reviewed && (filters.ReviewedLanguage is null ||
                                                                 x.LanguageIso ==
                                                                 filters.ReviewedLanguage)) is true)
            .Where(x => filters.Unverified is null ||
                        x.Translations?.Any(x =>
                                x.IsUnverified == filters.Unverified && (filters.UnverifiedLanguage is null ||
                                                                         x.LanguageIso == filters.UnverifiedLanguage))
                            is
                            true)
            .Where(x => filters.TagsToSkip is null || x.Tags.All(x => !filters.TagsToSkip.Contains(x)))
            .Where(x => filters.UntranslatedLanguage is null ||
                        string.IsNullOrWhiteSpace(x.Translations
                            .First(x => x.LanguageIso == filters.UntranslatedLanguage).Translation))
            .ToList();

        return new ListProjectKeysResponse { Keys = items, ProjectId = project.ProjectId };
    }

    [Action("List key IDs", Description = "List key IDs based on the provided filters")]
    public async Task<ListProjectKeyIdsResponse> ListKeyIds([ActionParameter] ProjectRequest project,
        [ActionParameter] ListProjectKeysBaseRequest input,
        [ActionParameter] ListProjectKeysFilters filters)
    {
        var keys = await GetProjectKeys(project, new ListProjectKeysRequest(input)
        {
            IncludeTranslations = true
        }, new ListProjectKeysFilters());

        var keyIds = keys.Keys.Where(x => filters.Reviewed is null ||
                                          x.Translations?.Any(x =>
                                              x.IsReviewed == filters.Reviewed &&
                                              (filters.ReviewedLanguage is null ||
                                               x.LanguageIso ==
                                               filters.ReviewedLanguage)) is true)
            .Where(x => filters.Unverified is null ||
                        x.Translations?.Any(x =>
                                x.IsUnverified == filters.Unverified && (filters.UnverifiedLanguage is null ||
                                                                         x.LanguageIso == filters.UnverifiedLanguage))
                            is
                            true)
            .Where(x => filters.TagsToSkip is null || x.Tags.All(x => !filters.TagsToSkip.Contains(x)))
            .Where(x => filters.UntranslatedLanguage is null ||
                        string.IsNullOrWhiteSpace(x.Translations
                            .First(x => x.LanguageIso == filters.UntranslatedLanguage).Translation))
            .Select(x => x.KeyId)
            .ToArray();
        
        return new()
        {
            KeyIds = keyIds
        };
    }

    [Action("Create key", Description = "Create key in project")]
    public async Task<KeyDto> CreateKey([ActionParameter] ProjectRequest project,
        [ActionParameter] CreateKeyInput input)
    {
        if (input.Platforms.Any(x => !LokaliseConstants.Platforms.Contains(x)))
            throw new Exception($"Platforms can only contain {String.Join(", ", LokaliseConstants.Platforms)}");

        var endpoint = $"/projects/{project.ProjectId}/keys";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new CreateKeyRequest(input));

        var response = await Client.ExecuteWithHandling<ListProjectKeysResponse>(request);
        return response.Keys.FirstOrDefault() ?? throw new("Unknown error occured during key creation");
    }

    [Action("Get key", Description = "Get key by ID")]
    public async Task<KeyDto> RetrieveKey([ActionParameter] RetrieveKeyRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/keys/{input.KeyId}";

        if (input.DisableReferences is not null)
            endpoint += $"?disable_references={input.DisableReferences.AsLokaliseQuery()}";

        var request = new LokaliseRequest(endpoint, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<KeyResponse>(request);

        return response.Key;
    }

    [Action("Delete key", Description = "Delete key by ID")]
    public Task DeleteKey([ActionParameter] DeleteKeyRequest input)
    {
        var endpoint = $"/projects/{input.ProjectId}/keys/{input.KeyId}";
        var request = new LokaliseRequest(endpoint, Method.Delete, Creds);

        return Client.ExecuteWithHandling(request);
    }

    #endregion
}