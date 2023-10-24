using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectBranchAddedHandler : BaseWebhookHandler
{
    const string SubscriptionEvent = "project.branch.added";

    public ProjectBranchAddedHandler([WebhookParameter] WebhookInput input) : base(SubscriptionEvent, input)
    {
    }
}