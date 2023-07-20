using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Comments;

public class CommentRequest
{
    [JsonPropertyName("comment")] public string Comment { get; set; }

    public CommentRequest(string text)
    {
        Comment = text;
    }
}