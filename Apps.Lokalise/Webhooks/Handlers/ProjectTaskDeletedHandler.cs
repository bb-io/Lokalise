using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectTaskDeletedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.task.deleted";

        public ProjectTaskDeletedHandler() : base(SubscriptionEvent) { }
    }
}