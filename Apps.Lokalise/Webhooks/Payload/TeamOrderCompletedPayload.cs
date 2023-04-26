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
    }


}