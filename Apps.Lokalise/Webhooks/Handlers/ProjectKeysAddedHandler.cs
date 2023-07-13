using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeysAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.keys.added";

        public ProjectKeysAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}