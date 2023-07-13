namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectLanguageSettingsChangedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.language.settings_changed";

        public ProjectLanguageSettingsChangedHandler() : base(SubscriptionEvent) { }
    }
}