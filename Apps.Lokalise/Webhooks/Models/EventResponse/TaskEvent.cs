﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class TaskEvent : BaseEvent
{
    [Display("Task ID")]
    public string TaskId { get; set; }

    [Display("Task type")]
    public string Type { get; set; }

    [Display("Task title")]
    public string Title { get; set; }

    //[Display("Task due date")]
    //public DateTime DueDate { get; set; }

    [Display("Task description")]
    public string Description { get; set; }
}