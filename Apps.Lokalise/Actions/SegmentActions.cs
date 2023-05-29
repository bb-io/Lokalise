using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Requests;
using Apps.Lokalise.Models.Responses.Files;
using Apps.Lokalise.Models.Responses.Segments;
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
    public class SegmentActions
    {
        [Action("List all segments", Description = "List all key segments")]
        public ListAllSegmentsResponse? ListAllSegments(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] ListAllSegmentsRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}/segments/{input.LanguageCode}", Method.Get, authenticationCredentialsProviders);
            var result = new SegmentsWrapper();
            try
            {
                result = client.Get<SegmentsWrapper>(request);
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    throw new Exception("Segmentation is not enabled or is not available in this project");
                }
            }
            return new ListAllSegmentsResponse()
            {
                Segments = result.Segments
            };
        }

        [Action("Get segment", Description = "Get segment by number")]
        public SegmentDto? GetSegment(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter] GetSegmentRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}/segments/{input.LanguageCode}/{input.SegmentNumber}", Method.Get, authenticationCredentialsProviders);
            return client.Get<SegmentDto>(request);
        }

        [Action("Update segment", Description = "Update segment by number")]
        public void UpdateSegment(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
                                    [ActionParameter] UpdateSegmentRequest input)
        {
            var client = new LokaliseClient();
            var request = new LokaliseRequest($"/projects/{input.ProjectId}/keys/{input.KeyId}/segments/{input.LanguageCode}/{input.SegmentNumber}", Method.Put, authenticationCredentialsProviders);
            request.AddJsonBody(new
            {
                value = input.NewValue
            });
            client.Execute(request);
        }
    }
}
