using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageSettings_changedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.settings_changed";

        public ProjectLanguageSettings_changedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}