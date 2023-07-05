using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class TeamOrderCompletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "team.order.completed";

        public TeamOrderCompletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}