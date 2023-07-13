using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationsUpdatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translations.updated";

        public ProjectTranslationsUpdatedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}