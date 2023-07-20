using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Comments;

public class CommentsResponse
{
    [JsonPropertyName("comments")]
    public Comment[] Comments { get; set; }
}