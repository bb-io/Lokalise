using Apps.Localise.Webhooks.Handlers;
namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyCommentAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.comment.added";

        public ProjectKeyCommentAddedHandler() : base(SubscriptionEvent) { }
    }
}