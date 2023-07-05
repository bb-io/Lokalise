using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.added";

        public ProjectKeyAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}