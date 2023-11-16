using Apps.Lokalise.Constants;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Requests.Projects;
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

    [Action("List all project keys", Description = "List all project keys")]
    public async Task<ListProjectKeysResponse> ListProjectKeys([ActionParameter] ProjectRequest project,
        [ActionParameter] ListProjectKeysRequest input)
    {
        var baseEndpoint = $"/projects/{project.ProjectId}/keys";
        var query = input.AsLokaliseDictionary().AllIsNotNull();

        var endpointWithQuery = baseEndpoint.WithQuery(query);

        var items = await Paginator.GetAll<KeysWrapper, KeyDto>(Creds, endpointWithQuery);

        return new(items);
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