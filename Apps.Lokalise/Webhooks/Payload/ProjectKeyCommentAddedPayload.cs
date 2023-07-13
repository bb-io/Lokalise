using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyCommentAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectKeyCommentAddedPayload : BasePayload>(myJsonResponse);
    public class Comment
    {
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public class Filenames
    {
        [JsonPropertyName("ios")] public string Ios { get; set; }
        [JsonPropertyName("android")] public string Android { get; set; }
        [JsonPropertyName("web")] public string Web { get; set; }
        [JsonPropertyName("other")] public string Other { get; set; }
    }

    public class KeyCommentAdded
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }

        [JsonPropertyName("filenames")]
        [Display("Filenames")]
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeyCommentAddedPayload : BasePayload
    {
        [JsonPropertyName("key")]
        [Display("Key")]
        public KeyCommentAdded Key { get; set; }

        [JsonPropertyName("comment")]
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
}