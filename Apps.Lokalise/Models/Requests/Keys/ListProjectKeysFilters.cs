using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class ListProjectKeysFilters
{
    public bool? Unverified { get; set; }
    
    public bool? Unreviewed { get; set; }
    
    [Display("Exclude tags")]
    public IEnumerable<string>? TagsToSkip { get; set; }
}