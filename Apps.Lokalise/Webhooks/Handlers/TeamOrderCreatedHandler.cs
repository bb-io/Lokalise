using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class TeamOrderCreatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "team.order.created";

        public TeamOrderCreatedHandler() : base(SubscriptionEvent) { }
    }
}