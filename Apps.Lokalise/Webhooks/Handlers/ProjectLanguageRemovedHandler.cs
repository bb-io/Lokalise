using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageRemovedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.removed";

        public ProjectLanguageRemovedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}