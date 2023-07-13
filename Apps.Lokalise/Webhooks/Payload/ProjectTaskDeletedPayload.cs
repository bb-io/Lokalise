using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskDeletedPayload : BasePayload
    {
        [JsonPropertyName("task")]
        public Task Task { get; set; }
    }

}