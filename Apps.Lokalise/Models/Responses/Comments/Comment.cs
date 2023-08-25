using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Comments;

public class Comment
{
    [JsonProperty("comment_id")]
    [Display("Comment ID")]
    public long CommentId { get; set; }

    [JsonProperty("key_id")]
    [Display("Key ID")]
    public long KeyId { get; set; }

    [JsonProperty("comment")]
    [Display("Comment")]
    public string CommentText { get; set; }

    [JsonProperty("added_by")]
    [Display("Added by")]
    public long AddedBy { get; set; }

    [JsonProperty("added_by_email")]
    [Display("Added by email")]
    public string AddedByEmail { get; set; }
    
    [JsonProperty("added_at_timestamp")]
    [Display("Added at timestamp")]
    public long AddedAtTimestamp { get; set; }
}