using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;

public class ListProjectKeysRequest : ListProjectKeysBaseRequest
{
    [JsonProperty("disable_references")]
    [Display("Disable references")]
    public bool? DisableReferences { get; set; }
        
    [JsonProperty("include_comments")]
    [Display("Include comments")]
    public bool? IncludeComments { get; set; }
        
    [JsonProperty("include_screenshots")]
    [Display("Include screenshots")]
    public bool? IncludeScreenshots { get; set; }
        
    [JsonProperty("include_translations")]
    [Display("Include translations")]
    public bool? IncludeTranslations { get; set; }
        
    [JsonProperty("filter_key_ids")]
    [Display("Filter Key IDs")]
    public string? FilterKeyIds { get; set; }
}