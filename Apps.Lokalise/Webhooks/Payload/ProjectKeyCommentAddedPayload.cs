using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload;

// ProjectKeyCommentAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeyCommentAddedPayload : BasePayload>(myJsonResponse);
public class Comment
{
    [JsonProperty("value")] public string Value { get; set; }
}

public class Filenames
{
    [JsonProperty("ios")] public string Ios { get; set; }
    [JsonProperty("android")] public string Android { get; set; }
    [JsonProperty("web")] public string Web { get; set; }
    [JsonProperty("other")] public string Other { get; set; }
}

public class KeyCommentAdded
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    [Display("Name")]
    public string Name { get; set; }

    [JsonProperty("filenames")]
    [Display("Filenames")]
    public Filenames Filenames { get; set; }
}

public class ProjectKeyCommentAddedPayload : BasePayload
{
    [JsonProperty("key")]
    [Display("Key")]
    public KeyCommentAdded Key { get; set; }

    [JsonProperty("comment")]
    [Display("Comment")]
    public Comment Comment { get; set; }

    public override KeyCommentEvent Convert()
    {
        return new KeyCommentEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            Id = Key.Id,
            Name = Key.Name,
            Comment = Comment.Value,
            IOS = Key.Filenames.Ios,
            Android = Key.Filenames.Android,
            Web = Key.Filenames.Web,
            Other = Key.Filenames.Other,
        };
    }
}