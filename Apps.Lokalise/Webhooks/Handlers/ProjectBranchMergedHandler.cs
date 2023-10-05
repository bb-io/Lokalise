using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers;

public class ProjectBranchMergedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.branch.merged";

    public ProjectBranchMergedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input) { }
}