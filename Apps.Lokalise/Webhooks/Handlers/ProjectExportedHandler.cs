using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectExportedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.exported";

        public ProjectExportedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}