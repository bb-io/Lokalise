using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Segments;

public class ListAllSegmentsQueryRequest
{
    [JsonPropertyName("disable_references")]
    [Display("Disable references")] 
    public bool? DisableReferences { get; set; }
    
    [JsonPropertyName("filter_is_reviewed")]
    [Display("Filter is reviewed")] 
    public bool? FilterIsReviewed { get; set; }
    
    [JsonPropertyName("filter_unverified")]
    [Display("Filter unverified")] 
    public bool? FilterUnverified { get; set; }
    
    [JsonPropertyName("filter_untranslated")]
    [Display("Filter untranslated")] 
    public bool? FilterUntranslated { get; set; }
    
    [JsonPropertyName("filter_qa_issues")]
    [Display("Filter qa issues")] 
    public string? FilterQaIssues { get; set; }
}