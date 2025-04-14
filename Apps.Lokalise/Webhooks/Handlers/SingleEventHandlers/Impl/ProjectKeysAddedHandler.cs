using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;

public class ProjectKeysAddedHandler : BaseWebhookBridgeHandler
{
    const string SubscriptionEvent = "project.keys.added";

    public ProjectKeysAddedHandler(InvocationContext invocationContext, [WebhookParameter] WebhookInput input) : base(invocationContext, SubscriptionEvent, input.Projects) { }
}