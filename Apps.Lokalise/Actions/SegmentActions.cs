using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Segments;
using Apps.Lokalise.Models.Responses.Segments;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using RestSharp;

namespace Apps.Lokalise.Actions
{
    [ActionList]
    public class SegmentActions
    {
        #region Fields

        private readonly LokaliseClient _client;

        #endregion

        #region Constructors

        public SegmentActions()
        {
            _client = new();
        }

        #endregion

        #region Actions

        [Action("List all segments", Description = "List all key segments")]
        public async Task<ListAllSegmentsResponse> ListAllSegments(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ListAllSegmentsPathRequest pathInput,
            [ActionParameter] ListAllSegmentsQueryRequest queryInput)
        {
            var creds = authenticationCredentialsProviders.ToArray();

            var endpoint = $"/projects/{pathInput.ProjectId}/keys/{pathInput.KeyId}/segments/{pathInput.LanguageCode}";
            var query = queryInput.AsDictionary().AllIsNotNull();

            var url = QueryHelpers.AddQueryString(endpoint, query);

            var segments = await Paginator.GetAll<SegmentsWrapper, SegmentDto>(creds, url);

            return new ListAllSegmentsResponse
            {
                Segments = segments
            };
        }

        [Action("Get segment", Description = "Get segment by number")]
        public Task<SegmentResponse> GetSegment(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] GetSegmentRequest input)
        {
            var endpoint =
                $"/projects/{input.ProjectId}/keys/{input.KeyId}/segments/{input.LanguageCode}/{input.SegmentNumber}";

            if (input.DisableReferences is not null)
                endpoint += $"?disable_references={input.DisableReferences.AsLokaliseQuery()}";

            var request = new LokaliseRequest(endpoint, Method.Get, authenticationCredentialsProviders);
            return _client.ExecuteWithHandling<SegmentResponse>(request);
        }

        [Action("Update segment", Description = "Update segment by number")]
        public Task<SegmentResponse> UpdateSegment(
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] UpdateSegmentPathRequest pathInput,
            [ActionParameter] UpdateSegmentBodyRequest body)
        {
            var endpoint =
                $"/projects/{pathInput.ProjectId}/keys/{pathInput.KeyId}/segments/{pathInput.LanguageCode}/{pathInput.SegmentNumber}";
            var request = new LokaliseRequest(endpoint, Method.Put, authenticationCredentialsProviders)
                .WithJsonBody(body);
            
            return _client.ExecuteWithHandling<SegmentResponse>(request);
        }

        #endregion
    }
}