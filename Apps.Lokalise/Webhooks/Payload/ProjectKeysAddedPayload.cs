using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectKeysAddedPayload : BasePayload
    {
        [JsonPropertyName("keys")]
        public List<KeyWithTags> Keys { get; set; }
    }


}