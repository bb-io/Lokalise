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

    [Action("Add comment", Description = "Add a comment to a key")]
    public Task<CommentsResponse> AddComment([ActionParameter] KeyRequest pathData,
        [ActionParameter] [Display("Comment")] string comment)
    {
        var endpoint = $"/projects/{pathData.ProjectId}/keys/{pathData.KeyId}/comments";
        var payload = new AddCommentsRequest(new List<string> { comment });

        var request = new LokaliseRequest(endpoint, Method.Post, Creds)
            .WithJsonBody(payload);

        return Client.ExecuteWithHandling<CommentsResponse>(request);
    }

    #endregion
}