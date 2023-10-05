using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class ProjectKeysDeletedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.keys.deleted";

    public ProjectKeysDeletedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}