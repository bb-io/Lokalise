using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Comments;

public class CommentsResponse
{
    [JsonProperty("comments")]
    public Comment[] Comments { get; set; }
}