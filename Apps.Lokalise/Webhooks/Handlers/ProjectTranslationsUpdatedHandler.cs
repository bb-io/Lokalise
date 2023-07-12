namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTranslationsUpdatedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.translations.updated";

        public ProjectTranslationsUpdatedHandler() : base(SubscriptionEvent) { }
    }
}