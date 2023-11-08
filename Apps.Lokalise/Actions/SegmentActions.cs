using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Segments;
using Apps.Lokalise.Models.Responses.Segments;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Extensions.System;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class SegmentActions : LokaliseInvocable
{
    public SegmentActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List all segments", Description = "List all key segments")]
    public async Task<ListAllSegmentsResponse> ListAllSegments([ActionParameter] ListAllSegmentsPathRequest pathInput,
        [ActionParameter] ListAllSegmentsQueryRequest queryInput)
    {
        var endpoint = $"/projects/{pathInput.ProjectId}/keys/{pathInput.KeyId}/segments/{pathInput.LanguageCode}";
        var query = queryInput.AsLokaliseDictionary().AllIsNotNull();

        var url = endpoint.WithQuery(query);

        var segments = await Paginator.GetAll<SegmentsWrapper, SegmentDto>(Creds, url);

        return new()
        {
            Segments = segments
        };
    }

    [Action("Get segment", Description = "Get segment by number")]
    public Task<SegmentResponse> GetSegment([ActionParameter] GetSegmentRequest input)
    {
        var endpoint =
            $"/projects/{input.ProjectId}/keys/{input.KeyId}/segments/{input.LanguageCode}/{input.SegmentNumber}";

        if (input.DisableReferences is not null)
            endpoint += $"?disable_references={input.DisableReferences.AsLokaliseQuery()}";

        var request = new LokaliseRequest(endpoint, Method.Get, Creds);
        return Client.ExecuteWithHandling<SegmentResponse>(request);
    }

    [Action("Update segment", Description = "Update segment by number")]
    public Task<SegmentResponse> UpdateSegment([ActionParameter] UpdateSegmentPathRequest pathInput,
        [ActionParameter] UpdateSegmentBodyRequest body)
    {
        var endpoint =
            $"/projects/{pathInput.ProjectId}/keys/{pathInput.KeyId}/segments/{pathInput.LanguageCode}/{pathInput.SegmentNumber}";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(body);

        return Client.ExecuteWithHandling<SegmentResponse>(request);
    }

    #endregion
}