using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskCreateRequest
{
    [JsonProperty("title")]
    [Display("Title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    [Display("Description")]
    public string? Description { get; set; }

    [JsonProperty("due_date")]
    [Display("Due Date")]
    public string? DueDate { get; set; }

    [JsonProperty("keys")]
    [Display("Keys")]
    public string[]? Keys { get; set; }

    [JsonProperty("languages")]
    [Display("Languages")]
    public TaskLanguage[]? Languages { get; set; }

    [JsonProperty("source_language_iso")]
    [Display("Source language code")]
    public string? SourceLanguageIso { get; set; }

    [JsonProperty("auto_close_languages")]
    [Display("Auto close languages")]
    public bool? AutoCloseLanguages { get; set; }

    [JsonProperty("auto_close_task")]
    [Display("Auto close task")]
    public bool? AutoCloseTask { get; set; }

    [JsonProperty("auto_close_items")]
    [Display("Auto close items")]
    public bool? AutoCloseItems { get; set; }

    [JsonProperty("task_type")]
    [Display("Task type")]
    [DataSource(typeof(TaskTypeDataHandler))]
    public string? TaskType { get; set; }

    [JsonProperty("parent_task_id")]
    [Display("Parent task ID")]
    public string? ParentTaskId { get; set; }

    [JsonProperty("closing_tags")]
    [Display("Closing tags")]
    public string[]? ClosingTags { get; set; }

    [JsonProperty("do_lock_translations")]
    [Display("Do lock translations")]
    public bool? DoLockTranslations { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    [Display("Custom translation status IDs")]
    public string[]? CustomTranslationStatusIds { get; set; }
}
