using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // TeamOrderCreatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<TeamOrderCreatedPayload : BasePayload>(myJsonResponse);
    public class Order
    {
        public string Id { get; set; }
        public string Provider { get; set; }
        public string Currency { get; set; }
        public double Total { get; set; }
    }

    public class TeamOrderCreatedPayload : BasePayload
    {
        public Order Order { get; set; }

        public new OrderEvent Convert()
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