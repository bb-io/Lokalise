using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyAddedPayload : BasePayload>(myJsonResponse);
    public class KeyWithTags
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Display("Name")]
        public string Name { get; set; }

        [JsonPropertyName("base_value")]
        [Display("Base Value")]
        public string BaseValue { get; set; }

        [JsonPropertyName("tags")]
        [Display("Tags")]
        public List<string> Tags { get; set; }
    }

    public class ProjectKeyAddedPayload : BasePayload
    {
        [JsonPropertyName("key")] public KeyWithTags Key { get; set; }
    }
}