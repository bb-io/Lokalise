using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyModifiedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.modified";

        public ProjectKeyModifiedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}