using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Comments;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Responses.Comments;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class CommentActions : LokaliseInvocable
{
    public CommentActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("Add comments", Description = "Add comments to the key")]
    public Task<CommentsResponse> AddComment([ActionParameter] KeyRequest pathData,
        [ActionParameter] [Display("Comments")] IEnumerable<string> comments)
    {
        var endpoint = $"/projects/{pathData.ProjectId}/keys/{pathData.KeyId}/comments";
        var payload = new AddCommentsRequest(comments);

        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload);

        return Client.ExecuteWithHandling<CommentsResponse>(request);
    }

    #endregion
}