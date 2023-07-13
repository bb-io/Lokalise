using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationUpdatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translation.updated";

        public ProjectTranslationUpdatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}