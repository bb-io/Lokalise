using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class BranchEvent : BaseEvent
{
    [Display("Branch name")]
    public string Name { get; set; }
}