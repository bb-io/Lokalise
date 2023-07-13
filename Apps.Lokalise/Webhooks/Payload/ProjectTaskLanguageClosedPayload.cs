using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskLanguageClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskLanguageClosedPayload : BasePayload>(myJsonResponse);

    public class ProjectTaskLanguageClosedPayload : BasePayload
    {
        [JsonPropertyName("task")]
        public Task Task { get; set; }
        
        [JsonPropertyName("language")]
        public Language Language { get; set; }
    }

}