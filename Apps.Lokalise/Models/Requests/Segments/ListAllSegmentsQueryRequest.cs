using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Segments;

public class ListAllSegmentsQueryRequest
{
    [JsonProperty("disable_references")]
    [Display("Disable references")] 
    public bool? DisableReferences { get; set; }
    
    [JsonProperty("filter_is_reviewed")]
    [Display("Filter is reviewed")] 
    public bool? FilterIsReviewed { get; set; }
    
    [JsonProperty("filter_unverified")]
    [Display("Filter unverified")] 
    public bool? FilterUnverified { get; set; }
    
    [JsonProperty("filter_untranslated")]
    [Display("Filter untranslated")] 
    public bool? FilterUntranslated { get; set; }
    
    [JsonProperty("filter_qa_issues")]
    [Display("Filter qa issues")] 
    public string? FilterQaIssues { get; set; }
}