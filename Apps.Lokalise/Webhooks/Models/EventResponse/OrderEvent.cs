﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class OrderEvent : BaseEvent
{
    [Display("Order ID")]
    public string Id { get; set; }

    [Display("Provider")]
    public string Provider { get; set; }
}