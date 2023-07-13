using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers
{
    public class ProjectKeyCommentAddedHandler : BaseWebhookHandler
    {
        const string SubscriptionEvent = "project.key.comment.added";

        public ProjectKeyCommentAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
    }
}