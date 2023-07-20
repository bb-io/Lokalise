using Apps.Lokalise.Extensions;
using Apps.Lokalise.Models.Requests.Comments;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Responses.Comments;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class CommentActions
{
    #region Fields

    private readonly LokaliseClient _client;

    #endregion

    #region Constructors

    public CommentActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("Add comment", Description = "Add a comment to the key")]
    public Task<CommentsResponse> AddComment(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] KeyRequest pathData,
        [ActionParameter] [Display("Comment")] string comment)
    {
        var endpoint = $"/projects/{pathData.ProjectId}/keys/{pathData.KeyId}/comments";
        var payload = new AddCommentsRequest(comment);

        var request = new LokaliseRequest(endpoint, Method.Post,
                authenticationCredentialsProviders)
            .WithJsonBody(payload);

        return _client.ExecuteWithHandling<CommentsResponse>(request);
    }

    #endregion
}