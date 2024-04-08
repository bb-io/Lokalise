using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Lokalise.Models.Requests.Tasks
{
    public class LanguageTaskCreateRequest
    {
        [Display("Title")] public string Title { get; set; }

        [JsonProperty("task_type")]
        [Display("Task type")]
        [StaticDataSource(typeof(TaskTypeDataHandler))]
        public string LokaliseTaskType { get; set; }

        [Display("Description")] public string? Description { get; set; }

        [Display("Due Date")] public DateTime? DueDate { get; set; }

        [DataSource(typeof(LanguageDataHandler))]
        [Display("Source language")] public string? SourceLanguageIso { get; set; }

        [Display("Target language")]
        [DataSource(typeof(LanguageDataHandler))]
        public string TargetLanguageIso { get; set; }

        [Display("Auto close languages")] public bool? AutoCloseLanguages { get; set; }

        [Display("Auto close task")] public bool? AutoCloseTask { get; set; }

        [Display("Auto close items")] public bool? AutoCloseItems { get; set; }

        [Display("Parent task ID")] public string? ParentTaskId { get; set; }

        [Display("Closing tags")] public IEnumerable<string>? ClosingTags { get; set; }

        [Display("Do lock translations")] public bool? DoLockTranslations { get; set; }

        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }


    }
}
