﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class KeyModifiedEvent : BaseEvent
{
    [Display("Key ID")]
    public string Id { get; set; }

    [Display("Key name")]
    public string Name { get; set; }

    [Display("Key previous name")]
    public string PreviousName { get; set; }

    [Display("iOS")]
    public string IOS { get; set; }

    [Display("Android")]
    public string Android { get; set; }

    [Display("Web")]
    public string Web { get; set; }

    [Display("Other")]
    public string Other { get; set; }
}