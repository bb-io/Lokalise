using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class UploadFileRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("Filename")]
        public string FileName { get; set; }

        public byte[] File { get; set; }

        [Display("Language code")]
        public string LanguageCode { get; set; }

        [Display("Convert placeholders")]
        public bool? ConvertPlaceholders { get; set; }

        [Display("Detect ICU plurals")]
        public bool? DetectIcuPlurals { get; set; }

        [Display("Tags")]
        public List<string>? Tags { get; set; }

        [Display("Tag inserted keys")]
        public bool? TagInsertedKeys { get; set; }

        [Display("Tag updated keys")]
        public bool? TagUpdatedKeys { get; set; }

        [Display("Tag skipped keys")]
        public bool? TagSkippedKeys { get; set; }

        [Display("Replace modified")]
        public bool? ReplaceModified { get; set; }

        [Display("Replace \\n")]
        public bool? ReplaceSlashN { get; set; }

        [Display("Key to values")]
        public bool? KeyToValues { get; set; }

        [Display("Distinguish by file")]
        public bool? DistinguishByFile { get; set; }

        [Display("Apply TM")]
        public bool? ApplyTm { get; set; }

        [Display("Use automations")]
        public bool? UseAutomations { get; set; }

        [Display("Hidden from contributors")]
        public bool? HiddenFromContributors { get; set; }

        [Display("Cleanup mode")]
        public bool? CleanupMode { get; set; }

        [Display("Custom status IDs")]
        public List<string>? CustomStatusIds { get; set; }

        [Display("Custom status inserted keys")]
        public bool? CustomStatusInsertedKeys { get; set; }

        [Display("Custom status updated keys")]
        public bool? CustomStatusUpdatededKeys { get; set; }

        [Display("Custom status skipped keys")]
        public bool? CustomStatusSkippedKeys { get; set; }

        [Display("Skip language detection")]
        public bool? SkipLanguageDetection { get; set; }

        [Display("Format")]
        public string? Format { get; set; }

        [Display("Filter task ID")]
        public int? FilterTaskId { get; set; }
    }
}
