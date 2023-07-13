using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectImportedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.imported";

        public ProjectImportedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}