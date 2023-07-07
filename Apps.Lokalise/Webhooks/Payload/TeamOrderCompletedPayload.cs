using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCompletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<TeamOrderCompletedPayload : BasePayload>(myJsonResponse);
    public class OrderCompleted
    {
        public string Id { get; set; }
        public string Provider { get; set; }
    }

    public class TeamOrderCompletedPayload : BasePayload
    {
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