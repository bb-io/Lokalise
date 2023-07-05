using Apps.Localise.Webhooks.Handlers;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationProofreadHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translation.proofread";

        public ProjectTranslationProofreadHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}