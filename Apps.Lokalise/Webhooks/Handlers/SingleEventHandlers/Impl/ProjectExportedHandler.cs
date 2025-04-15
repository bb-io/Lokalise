using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectExportedHandler : BaseWebhookBridgeHandler
{
    const string SubscriptionEvent = "project.exported";

    public ProjectExportedHandler(InvocationContext invocation, [WebhookParameter] WebhookInput input) : base(invocation, SubscriptionEvent, input.Projects) { }
}