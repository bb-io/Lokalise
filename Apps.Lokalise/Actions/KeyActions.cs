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
using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Apps.Lokalise.Actions;

[ActionList("Keys")]
public class KeyActions(InvocationContext invocationContext) : LokaliseInvocable(invocationContext)
{
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
        
        var projectendpoint = $"/projects/{project.ProjectId}";
        var projectrequest = new LokaliseRequest(projectendpoint, Method.Get, Creds);
        var projectinfo = await Client.ExecuteWithHandling<ProjectResponse>(projectrequest);

        foreach (var item in items) 
        {
            item.SourceTranslation = item.Translations?.First(x => x.LanguageIso == projectinfo.BaseLanguageIso);
            item.Translations = item.Translations?.Where(x => x.LanguageIso != projectinfo.BaseLanguageIso).ToList();
        }

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

        var keys = items.Select(c => new KeyWithDate(c)).ToArray();

        if (filters.DateFrom.HasValue)
        { keys = keys.Where(x => x.CreatedAt >= filters.DateFrom).ToArray(); }

        if (filters.DateTo.HasValue)
        { keys = keys.Where(x => x.CreatedAt <= filters.DateTo).ToArray(); }


        return new ListProjectKeysResponse { Keys = keys, ProjectId = project.ProjectId, TotalCount = keys.Count()};
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
            .Where(x => !filters.DateFrom.HasValue || x.CreatedAt >= filters.DateFrom)
            .Where(x => !filters.DateTo.HasValue || x.CreatedAt <= filters.DateTo)
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
            throw new PluginMisconfigurationException($"Platforms can only contain {String.Join(", ", LokaliseConstants.Platforms)}");

        var endpoint = $"/projects/{project.ProjectId}/keys";
        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(new CreateKeyRequest(input));

        var response = await Client.ExecuteWithHandling<ListProjectCreatedKeysResponse>(request);
        return response.Keys.FirstOrDefault() ?? throw new("Unknown error occured during key creation");
    }

    [Action("Get key", Description = "Get key by ID")]
    public async Task<KeyDto> RetrieveKey([ActionParameter] RetrieveKeyRequest input)
    {

        if (string.IsNullOrWhiteSpace(input.ProjectId))
            throw new PluginMisconfigurationException("Project ID cannot be null or empty. Please check your input and try again");

        if (string.IsNullOrWhiteSpace(input.KeyId))
            throw new PluginMisconfigurationException("Key ID cannot be null or empty. Please check your input and try again");


            var endpoint = $"/projects/{input.ProjectId}/keys/{input.KeyId}";

        if (input.DisableReferences is not null)
            endpoint += $"?disable_references={input.DisableReferences.AsLokaliseQuery()}";

        var request = new LokaliseRequest(endpoint, Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<KeyResponse>(request);

        var projectendpoint = $"/projects/{input.ProjectId}";
        var projectrequest = new LokaliseRequest(projectendpoint, Method.Get, Creds);
        var projectinfo = await Client.ExecuteWithHandling<ProjectResponse>(projectrequest);
        var _key = response.Key;
        _key.SourceTranslation = _key.Translations?.FirstOrDefault(x => x.LanguageIso == projectinfo.BaseLanguageIso);
        _key.Translations = _key.Translations?.Where(x => x.LanguageIso != projectinfo.BaseLanguageIso).ToList();
        
        return _key;
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