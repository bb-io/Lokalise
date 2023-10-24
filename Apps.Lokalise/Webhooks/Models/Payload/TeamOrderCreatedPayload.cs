using Apps.Lokalise.Webhooks.Models.EventResponse;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// TeamOrderCreatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<TeamOrderCreatedPayload : BasePayload>(myJsonResponse);
public class Order
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("provider")] public string Provider { get; set; }
    [JsonProperty("currency")] public string Currency { get; set; }
    [JsonProperty("total")] public double Total { get; set; }
}

public class TeamOrderCreatedPayload : BasePayload
{
    [JsonProperty("order")] public Order Order { get; set; }

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