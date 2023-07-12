namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageSettings_changedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.settings_changed";

        public ProjectLanguageSettings_changedHandler() : base(SubscriptionEvent) { }
    }
}