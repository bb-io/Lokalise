using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Comments;

public class Comment
{
    [JsonPropertyName("comment_id")]
    [Display("Comment ID")]
    public long CommentId { get; set; }

    [JsonPropertyName("key_id")]
    [Display("Key ID")]
    public long KeyId { get; set; }

    [JsonPropertyName("comment")]
    [Display("Comment")]
    public string CommentText { get; set; }

    [JsonPropertyName("added_by")]
    [Display("Added by")]
    public long AddedBy { get; set; }

    [JsonPropertyName("added_by_email")]
    [Display("Added by email")]
    public string AddedByEmail { get; set; }
    
    [JsonPropertyName("added_at_timestamp")]
    [Display("Added at timestamp")]
    public long AddedAtTimestamp { get; set; }
}