using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects
{
    public class ListProjectKeysRequest
    {
        [JsonPropertyName("disable_references")]
        [Display("Disable references")]
        public bool? DisableReferences { get; set; }
        
        [JsonPropertyName("include_comments")]
        [Display("Include comments")]
        public bool? IncludeComments { get; set; }
        
        [JsonPropertyName("include_screenshots")]
        [Display("Include screenshots")]
        public bool? IncludeScreenshots { get; set; }
        
        [JsonPropertyName("include_translations")]
        [Display("Include translations")]
        public bool? IncludeTranslations { get; set; }
        
        [JsonPropertyName("filter_translation_lang_ids")]
        [Display("Filter translation lang ids")]
        public string? FilterTranslationLangIds { get; set; }
        
        [JsonPropertyName("filter_tags")]
        [Display("Filter tags")]
        public string? FilterTags { get; set; }
        
        [JsonPropertyName("filter_filenames")]
        [Display("Filter filenames")]
        public string? FilterFilenames { get; set; }
        
        [JsonPropertyName("filter_keys")]
        [Display("Filter keys")]
        public string? FilterKeys { get; set; }
        
        [JsonPropertyName("filter_key_ids")]
        [Display("Filter key ids")]
        public string? FilterKeyIds { get; set; }
        
        [JsonPropertyName("filter_platforms")]
        [Display("Filter platforms")]
        public string? FilterPlatforms { get; set; }
        
        [JsonPropertyName("filter_untranslated")]
        [Display("Filter untranslated")]
        public bool? FilterUntranslated { get; set; }
        
        [JsonPropertyName("filter_qa_issues")]
        [Display("Filter qa issues")]
        public string? FilterQaIssues { get; set; }
        
        [JsonPropertyName("filter_archived")]
        [Display("Filter archived")]
        public string? FilterArchived { get; set; }
    }
}
