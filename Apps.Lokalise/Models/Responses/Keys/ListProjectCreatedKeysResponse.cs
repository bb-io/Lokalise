using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Keys;

public class ListProjectCreatedKeysResponse
{
    public IEnumerable<KeyDto> Keys { get; set; }
    
    [Display("Project ID")]
    public string ProjectId { get; set; }

    [Display("Total count")]
    public int TotalCount { get; set; }
}