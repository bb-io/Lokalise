using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskCreateRequest
{
    [JsonPropertyName("title")]
    [Display("Title")]
    public string Title { get; set; }

    [JsonPropertyName("description")]
    [Display("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("due_date")]
    [Display("Due Date")]
    public string? DueDate { get; set; }

    [JsonPropertyName("keys")]
    [Display("Keys")]
    public string[]? Keys { get; set; }

    [JsonPropertyName("languages")]
    [Display("Languages")]
    public TaskLanguage[]? Languages { get; set; }

    [JsonPropertyName("source_language_iso")]
    [Display("Source language code")]
    public string? SourceLanguageIso { get; set; }

    [JsonPropertyName("auto_close_languages")]
    [Display("Auto close languages")]
    public bool? AutoCloseLanguages { get; set; }

    [JsonPropertyName("auto_close_task")]
    [Display("Auto close task")]
    public bool? AutoCloseTask { get; set; }

    [JsonPropertyName("auto_close_items")]
    [Display("Auto close items")]
    public bool? AutoCloseItems { get; set; }

    [JsonPropertyName("task_type")]
    [Display("Task type")]
    public string? TaskType { get; set; }

    [JsonPropertyName("parent_task_id")]
    [Display("Parent task ID")]
    public string? ParentTaskId { get; set; }

    [JsonPropertyName("closing_tags")]
    [Display("Closing tags")]
    public string[]? ClosingTags { get; set; }

    [JsonPropertyName("do_lock_translations")]
    [Display("Do lock translations")]
    public bool? DoLockTranslations { get; set; }

    [JsonPropertyName("custom_translation_status_ids")]
    [Display("Custom translation status IDs")]
    public string[]? CustomTranslationStatusIds { get; set; }
}
