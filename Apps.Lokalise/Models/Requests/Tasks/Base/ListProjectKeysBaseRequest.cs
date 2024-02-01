using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks.Base;

public class ListProjectKeysBaseRequest
{
    [JsonProperty("filter_platforms")]
    [Display("Filter key platforms")]
    public string? FilterPlatforms { get; set; }
        
    [JsonProperty("filter_untranslated")]
    [Display("Filter untranslated keys")]
    public bool? FilterUntranslated { get; set; }
        
    [JsonProperty("filter_qa_issues")]
    [Display("Filter qa issues")]
    public string? FilterQaIssues { get; set; }
        
    [JsonProperty("filter_archived")]
    [Display("Filter archived keys")]
    public string? FilterArchived { get; set; }
    
    [JsonProperty("filter_translation_lang_ids")]
    [Display("Filter translation language IDs")]
    public string? FilterTranslationLangIds { get; set; }
        
    [JsonProperty("filter_tags")]
    [Display("Include tags")]
    public string? FilterTags { get; set; }
        
    [JsonProperty("filter_filenames")]
    [Display("Filter filenames")]
    public string? FilterFilenames { get; set; }
        
    [JsonProperty("filter_keys")]
    [Display("Filter keys")]
    public string? FilterKeys { get; set; }
}