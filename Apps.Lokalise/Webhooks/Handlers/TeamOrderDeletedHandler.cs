namespace Apps.Lokalise.Webhooks.Handlers
{
    public class TeamOrderDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "team.order.deleted";

        public TeamOrderDeletedHandler() : base(SubscriptionEvent) { }
    }
}