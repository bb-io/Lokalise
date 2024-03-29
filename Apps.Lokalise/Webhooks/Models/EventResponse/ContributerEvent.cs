﻿using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class ContributerEvent : BaseEvent
{
    [Display("Contributer email")]
    public string Email { get; set; }
}