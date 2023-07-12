namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageRemovedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.removed";

        public ProjectLanguageRemovedHandler() : base(SubscriptionEvent) { }
    }
}