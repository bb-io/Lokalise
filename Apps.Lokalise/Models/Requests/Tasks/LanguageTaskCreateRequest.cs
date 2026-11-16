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

        [Display("Description", Description = "Task description. Used as AI instructions for Automatic translation and LQA by AI.")] public string? Description { get; set; }

        [Display("Due date")] public DateTime? DueDate { get; set; }

        [DataSource(typeof(LanguageDataHandler))]
        [Display("Source language")] public string? SourceLanguageIso { get; set; }

        [Display("Target language")]
        [DataSource(typeof(LanguageDataHandler))]
        public string TargetLanguageIso { get; set; }

        [Display("Auto close languages", Description = "Must be true or omitted for Automatic translation and LQA by AI.")] public bool? AutoCloseLanguages { get; set; }

        [Display("Auto close task", Description = "Must be true or omitted for Automatic translation and LQA by AI.")] public bool? AutoCloseTask { get; set; }

        [Display("Auto close items", Description = "Must be true or omitted for Automatic translation. Ignored and omitted for LQA by AI, including false.")] public bool? AutoCloseItems { get; set; }

        [Display("Translation engine", Description = "Automatic translation only. AI (default), DeepL, or Google. DeepL and Google cannot include AI scoring.")]
        [StaticDataSource(typeof(TranslationEngineDataHandler))]
        public string? TranslationEngine { get; set; }

        [Display("Save AI translation to TM", Description = "Automatic translation only. Save AI/MT output to translation memory. Defaults to false.")]
        public bool? SaveAiTranslationToTm { get; set; }

        [Display("Apply AI TM 100% matches", Description = "Automatic translation only. Apply exact translation memory matches. Defaults to false.")]
        public bool? ApplyAiTm100Matches { get; set; }

        [Display("Mark verified", Description = "Automatic translation only. Mark translations as verified. Defaults to true.")]
        public bool? MarkVerified { get; set; }

        [Display("Translate all segments", Description = "Automatic translation only, in projects with segmentation enabled. Include existing translations and TM matches. Defaults to false.")]
        public bool? TranslateAllSegments { get; set; }

        [Display("Include AI score", Description = "Automatic translation only, using the AI engine. Requires AI scoring in your Lokalise plan. Defaults to false.")]
        public bool? IncludeAiScore { get; set; }

        [Display("Parent task ID")] public string? ParentTaskId { get; set; }

        [Display("Closing tags")] public IEnumerable<string>? ClosingTags { get; set; }

        [Display("Do lock translations")] public bool? DoLockTranslations { get; set; }

        [Display("Custom translation status IDs")]
        public IEnumerable<string>? CustomTranslationStatusIds { get; set; }


    }
}
