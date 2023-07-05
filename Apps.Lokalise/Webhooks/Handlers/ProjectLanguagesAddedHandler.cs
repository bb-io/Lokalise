using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguagesAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.languages.added";

        public ProjectLanguagesAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}