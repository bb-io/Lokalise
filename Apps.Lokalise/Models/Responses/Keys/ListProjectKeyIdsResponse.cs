using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Keys;

public class ListProjectKeyIdsResponse
{
    [Display("Key IDs")]
    public IEnumerable<string> KeyIds { get;set; }
}