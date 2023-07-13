using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCompletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<TeamOrderCompletedPayload : BasePayload>(myJsonResponse);
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