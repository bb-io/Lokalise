using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationProofreadHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translation.proofread";

        public ProjectTranslationProofreadHandler() : base(SubscriptionEvent) { }
    }
}