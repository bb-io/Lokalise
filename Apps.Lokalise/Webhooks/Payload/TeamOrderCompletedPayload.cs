using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCompletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<TeamOrderCompletedPayload : BasePayload>(myJsonResponse);
    public class OrderCompleted
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("provider")]
        public string Provider { get; set; }
    }

    public class TeamOrderCompletedPayload : BasePayload
    {
        [JsonPropertyName("order")]
        public OrderCompleted Order { get; set; }
    }


}