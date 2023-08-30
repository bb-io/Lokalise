using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Comments;

public class CommentRequest
{
    [JsonProperty("comment")] public string Comment { get; set; }

    public CommentRequest(string text)
    {
        Comment = text;
    }
}