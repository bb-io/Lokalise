using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload;

// TeamOrderCompletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<TeamOrderCompletedPayload : BasePayload>(myJsonResponse);
public class OrderCompleted
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("provider")]
    public string Provider { get; set; }
}

public class TeamOrderCompletedPayload : BasePayload
{
    [JsonProperty("order")]
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