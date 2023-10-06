using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models;

public class TaskLeverageEvent : BaseEvent
{
    [Display("Task ID")]
    public int TaskId { get; set; }

    [Display("Task title")]
    public string Title { get; set; }

    [Display("Task description")]
    public string Description { get; set; }

    [Display("TM leverage")]
    public InitialTmLeverage Leverage { get; set; } 
}