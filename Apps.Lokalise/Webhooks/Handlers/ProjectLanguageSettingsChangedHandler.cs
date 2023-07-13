using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageSettingsChangedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.settings_changed";

        public ProjectLanguageSettingsChangedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}