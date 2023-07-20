using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Comments;

public class AddCommentsRequest
{
    [JsonPropertyName("comments")] public CommentRequest[] Comments { get; set; }

    public AddCommentsRequest(string text)
    {
        Comments = new[] { new CommentRequest(text) };
    }
}