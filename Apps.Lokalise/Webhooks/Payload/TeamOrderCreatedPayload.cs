using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCreatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<TeamOrderCreatedPayload : BasePayload>(myJsonResponse);
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

        public override OrderEvent Convert()
        {
            return new OrderEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id = Order.Id,
                Provider = Order.Provider,
            };
        }
    }
}