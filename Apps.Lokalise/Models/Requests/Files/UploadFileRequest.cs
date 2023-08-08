using System.Text.Json.Serialization;
using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class UploadFileRequest
    {
        [Display("File name")]
        [JsonPropertyName("filename")]
        public string FileName { get; set; }

        [JsonPropertyName("data")]
        public byte[] File { get; set; }
        
        [Display("Language code")]
        [JsonPropertyName("lang_iso")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
        
        [JsonPropertyName("convert_placeholders")]
        [Display("Convert placeholders")]
        public bool? ConvertPlaceHolders { get; set; }
        
        [JsonPropertyName("detect_icu_plurals")]
        [Display("Detect icu plurals")]
        public bool? DetectIcuPlurals { get; set; }
        
        [JsonPropertyName("tags")]
        public IEnumerable<string>? Tags { get; set; }
        
        [JsonPropertyName("tag_inserted_keys")]
        [Display("Tag inserted keys")]
        public bool? TagInsertedKeys { get; set; }
        
        [JsonPropertyName("tag_updated_keys")]
        [Display("Tag updated keys")]
        public bool? TagUpdatedKeys { get; set; }
        
        [JsonPropertyName("tag_skipped_keys")]
        [Display("Tag skipped keys")]
        public bool? TagSkippedKeys { get; set; }
        
        [JsonPropertyName("replace_modified")]
        [Display("Replace modified?")]
        public bool? ReplaceModified { get; set; }
        
        [JsonPropertyName("slashn_to_linebreak")]
        [Display("Slashn to linebreak")]
        public bool? SlashnToLinebreak { get; set; }
        
        [JsonPropertyName("keys_to_values")]
        [Display("Keys to values")]
        public bool? KeysToValues { get; set; }
        
        [JsonPropertyName("distinguish_by_file")]
        [Display("Distinguish by file")]
        public bool? DistinguishByFile { get; set; }
        
        [JsonPropertyName("apply_tm")]
        [Display("Apply TM")]
        public bool? ApplyTM { get; set; }
        
        [JsonPropertyName("use_automations")]
        [Display("Use automations")]
        public bool? UseAutomations { get; set; }
        
        [JsonPropertyName("hidden_from_contributors")]
        [Display("Hidden from contributors")]
        public bool? HiddenFromContributors { get; set; }
        
        [JsonPropertyName("cleanup_mode")]
        [Display("Cleanup mode")]
        public bool? CleanupMode { get; set; }
        
        [JsonPropertyName("custom_translation_status_ids")]
        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
        
        [JsonPropertyName("custom_translation_status_inserted_keys")]
        [Display("Custom translation status inserted keys")]
        public bool? CustomTranslationStatusInsertedKeys { get; set; }
        
        [JsonPropertyName("custom_translation_status_updated_keys")]
        [Display("Custom translation status updated keys")]
        public bool? CustomTranslationStatusUpdatedKeys { get; set; }
        
        [JsonPropertyName("custom_translation_status_skipped_keys")]
        [Display("Custom translation status skipped keys")]
        public bool? CustomTranslationStatusSkippedKeys { get; set; }
        
        [JsonPropertyName("skip_detect_lang_iso")]
        [Display("Skip detection of language by file name")]
        public bool? SkipDetectLangIso { get; set; }
        
        [JsonPropertyName("format")]
        public string? Format { get; set; }
        
        [JsonPropertyName("filter_task_id")]
        [Display("Filter task ID")]
        public long? FilterTaskId { get; set; }
    }
}
