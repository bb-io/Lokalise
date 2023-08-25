using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class UploadFileRequest
    {
        [Display("File name")]
        [JsonProperty("filename")]
        public string FileName { get; set; }

        [JsonProperty("data")]
        public byte[] File { get; set; }
        
        [Display("Language code")]
        [JsonProperty("lang_iso")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
        
        [JsonProperty("convert_placeholders")]
        [Display("Convert placeholders")]
        public bool? ConvertPlaceHolders { get; set; }
        
        [JsonProperty("detect_icu_plurals")]
        [Display("Detect icu plurals")]
        public bool? DetectIcuPlurals { get; set; }
        
        [JsonProperty("tags")]
        public IEnumerable<string>? Tags { get; set; }
        
        [JsonProperty("tag_inserted_keys")]
        [Display("Tag inserted keys")]
        public bool? TagInsertedKeys { get; set; }
        
        [JsonProperty("tag_updated_keys")]
        [Display("Tag updated keys")]
        public bool? TagUpdatedKeys { get; set; }
        
        [JsonProperty("tag_skipped_keys")]
        [Display("Tag skipped keys")]
        public bool? TagSkippedKeys { get; set; }
        
        [JsonProperty("replace_modified")]
        [Display("Replace modified?")]
        public bool? ReplaceModified { get; set; }
        
        [JsonProperty("slashn_to_linebreak")]
        [Display("Slashn to linebreak")]
        public bool? SlashnToLinebreak { get; set; }
        
        [JsonProperty("keys_to_values")]
        [Display("Keys to values")]
        public bool? KeysToValues { get; set; }
        
        [JsonProperty("distinguish_by_file")]
        [Display("Distinguish by file")]
        public bool? DistinguishByFile { get; set; }
        
        [JsonProperty("apply_tm")]
        [Display("Apply TM")]
        public bool? ApplyTM { get; set; }
        
        [JsonProperty("use_automations")]
        [Display("Use automations")]
        public bool? UseAutomations { get; set; }
        
        [JsonProperty("hidden_from_contributors")]
        [Display("Hidden from contributors")]
        public bool? HiddenFromContributors { get; set; }
        
        [JsonProperty("cleanup_mode")]
        [Display("Cleanup mode")]
        public bool? CleanupMode { get; set; }
        
        [JsonProperty("custom_translation_status_ids")]
        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
        
        [JsonProperty("custom_translation_status_inserted_keys")]
        [Display("Custom translation status inserted keys")]
        public bool? CustomTranslationStatusInsertedKeys { get; set; }
        
        [JsonProperty("custom_translation_status_updated_keys")]
        [Display("Custom translation status updated keys")]
        public bool? CustomTranslationStatusUpdatedKeys { get; set; }
        
        [JsonProperty("custom_translation_status_skipped_keys")]
        [Display("Custom translation status skipped keys")]
        public bool? CustomTranslationStatusSkippedKeys { get; set; }
        
        [JsonProperty("skip_detect_lang_iso")]
        [Display("Skip detection of language by file name")]
        public bool? SkipDetectLangIso { get; set; }
        
        [JsonProperty("format")]
        public string? Format { get; set; }
        
        [JsonProperty("filter_task_id")]
        [Display("Filter task ID")]
        public long? FilterTaskId { get; set; }
    }
}
