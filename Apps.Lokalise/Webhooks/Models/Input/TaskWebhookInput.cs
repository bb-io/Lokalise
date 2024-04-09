using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Webhooks.Models.Input;

public class TaskWebhookInput : WebhookInput
{
    [Display("Task type")]
    [StaticDataSource(typeof(TaskTypeDataHandler))]
    public string? TaskType { get; set; }
}