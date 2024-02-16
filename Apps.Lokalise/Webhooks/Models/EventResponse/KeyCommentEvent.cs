﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeyCommentEvent : BaseEvent
{
    [Display("Key ID")]
    public string Id { get; set; }

    [Display("Key name")]
    public string Name { get; set; }

    [Display("Comment")]
    public string Comment { get; set; }

    [Display("iOS")]
    public string? IOS { get; set; }

    [Display("Android")]
    public string? Android { get; set; }

    [Display("Web")]
    public string? Web { get; set; }

    [Display("Other")]
    public string? Other { get; set; }
}