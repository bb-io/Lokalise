using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects
{
    public class ListProjectKeysRequest
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
        
        [JsonProperty("filter_translation_lang_ids")]
        [Display("Filter translation lang ids")]
        public string? FilterTranslationLangIds { get; set; }
        
        [JsonProperty("filter_tags")]
        [Display("Filter tags")]
        public string? FilterTags { get; set; }
        
        [JsonProperty("filter_filenames")]
        [Display("Filter filenames")]
        public string? FilterFilenames { get; set; }
        
        [JsonProperty("filter_keys")]
        [Display("Filter keys")]
        public string? FilterKeys { get; set; }
        
        [JsonProperty("filter_key_ids")]
        [Display("Filter Key IDs")]
        public string? FilterKeyIds { get; set; }
        
        [JsonProperty("filter_platforms")]
        [Display("Filter platforms")]
        public string? FilterPlatforms { get; set; }
        
        [JsonProperty("filter_untranslated")]
        [Display("Filter untranslated")]
        public bool? FilterUntranslated { get; set; }
        
        [JsonProperty("filter_qa_issues")]
        [Display("Filter qa issues")]
        public string? FilterQaIssues { get; set; }
        
        [JsonProperty("filter_archived")]
        [Display("Filter archived")]
        public string? FilterArchived { get; set; }
    }
}
