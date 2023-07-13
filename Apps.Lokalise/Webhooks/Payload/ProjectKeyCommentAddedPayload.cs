using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyCommentAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyCommentAddedPayload : BasePayload>(myJsonResponse);
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
    }
}