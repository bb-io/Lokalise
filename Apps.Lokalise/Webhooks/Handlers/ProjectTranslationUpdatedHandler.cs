namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationUpdatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translation.updated";

        public ProjectTranslationUpdatedHandler() : base(SubscriptionEvent) { }
    }
}