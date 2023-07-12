namespace Apps.Lokalise.Webhooks.Handlers
{
    public class TeamOrderCompletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "team.order.completed";

        public TeamOrderCompletedHandler() : base(SubscriptionEvent) { }
    }
}