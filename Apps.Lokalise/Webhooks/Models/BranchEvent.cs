using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models;

public class BranchEvent : BaseEvent
{
    [Display("Branch name")]
    public string Name { get; set; }
}