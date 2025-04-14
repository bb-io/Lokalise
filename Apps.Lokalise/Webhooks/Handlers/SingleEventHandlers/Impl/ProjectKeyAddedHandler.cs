using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Bridge.Base.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;
public class ProjectKeyAddedHandler : BaseWebhookBridgeHandler
{
    const string SubscriptionEvent = "project.key.added";

    public ProjectKeyAddedHandler(InvocationContext invocationContext, [WebhookParameter] ProjectInputOption projectInfo) : base(invocationContext, SubscriptionEvent, projectInfo.ProjectId) { }
}