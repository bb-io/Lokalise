using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests.Translations
{
    public class ListTranslationQueryRequest
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

        [JsonProperty("filter_active_task_id")]
        [Display("Filter Active Task ID")]
        public string? FilterActiveTaskID { get; set; }

    }
}
