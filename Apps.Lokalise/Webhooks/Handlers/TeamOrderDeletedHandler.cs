using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class TeamOrderDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "team.order.deleted";

        public TeamOrderDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}