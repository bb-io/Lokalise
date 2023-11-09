using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks.Models.Input;

public class TaskWebhookInput : WebhookInput
{
    [Display("Task type")]
    [DataSource(typeof(TaskTypeDataHandler))]
    public string? TaskType { get; set; }
}