using System.Text.Json.Serialization;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCreatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<TeamOrderCreatedPayload : BasePayload>(myJsonResponse);
    public class Order
    {
        [JsonPropertyName("id")] public string Id { get; set; }
        [JsonPropertyName("provider")] public string Provider { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("total")] public double Total { get; set; }
    }

    public class TeamOrderCreatedPayload : BasePayload
    {
        [JsonPropertyName("order")] public Order Order { get; set; }
    }
}