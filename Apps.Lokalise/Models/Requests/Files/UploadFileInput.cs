using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class UploadFileInput
    {
        [Display("File name")]
        public string? FileName { get; set; }

        public File File { get; set; }
        
        [Display("Language code")]
        [DataSource(typeof(LanguageDataHandler))]
        public string LanguageCode { get; set; }
        
        [Display("Convert placeholders")]
        public bool? ConvertPlaceHolders { get; set; }
        
        [Display("Detect icu plurals")]
        public bool? DetectIcuPlurals { get; set; }
        
        public IEnumerable<string>? Tags { get; set; }
        
        [Display("Tag inserted keys")]
        public bool? TagInsertedKeys { get; set; }
        
        [Display("Tag updated keys")]
        public bool? TagUpdatedKeys { get; set; }
        
        [Display("Tag skipped keys")]
        public bool? TagSkippedKeys { get; set; }
        
        [Display("Replace modified?")]
        public bool? ReplaceModified { get; set; }
        
        [Display("Slashn to linebreak")]
        public bool? SlashnToLinebreak { get; set; }
        
        [Display("Keys to values")]
        public bool? KeysToValues { get; set; }
        
        [Display("Distinguish by file")]
        public bool? DistinguishByFile { get; set; }
        
        [Display("Apply TM")]
        public bool? ApplyTM { get; set; }
        
        [Display("Use automations")]
        public bool? UseAutomations { get; set; }
        
        [Display("Hidden from contributors")]
        public bool? HiddenFromContributors { get; set; }
        
        [Display("Cleanup mode")]
        public bool? CleanupMode { get; set; }
        
        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
        
        [Display("Custom translation status inserted keys")]
        public bool? CustomTranslationStatusInsertedKeys { get; set; }
        
        [Display("Custom translation status updated keys")]
        public bool? CustomTranslationStatusUpdatedKeys { get; set; }
        
        [Display("Custom translation status skipped keys")]
        public bool? CustomTranslationStatusSkippedKeys { get; set; }
        
        [Display("Skip detection of language by file name")]
        public bool? SkipDetectLangIso { get; set; }
        
        public string? Format { get; set; }
        
        [Display("Filter task ID")]
        public long? FilterTaskId { get; set; }
    }
}
