using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskCreatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskCreatedPayload : BasePayload
    {
        [JsonPropertyName("task")]
        public Task Task { get; set; }
    }

}