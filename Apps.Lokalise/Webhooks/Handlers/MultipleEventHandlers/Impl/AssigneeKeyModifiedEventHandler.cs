using Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Base;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Lokalise.Webhooks.Handlers.MultipleEventHandlers.Impl;

public class AssigneeKeyModifiedEventHandler : MultipleEventHandler
{
    protected override string[] SubscriptionEvents => new[]
    {
        "project.task.created", "project.key.modified", "project.keys.added", "project.key.added"
    };

    public AssigneeKeyModifiedEventHandler([WebhookParameter] WebhookUserInput input) : base(input)
    {
    }
}