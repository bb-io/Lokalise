using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskUpdateRequest
{
    [JsonPropertyName("title")]
    [Display("Title")]
    public string? Title { get; set; }

    [JsonPropertyName("due_date")]
    [Display("Due date")]
    public string? DueDate { get; set; }

    [JsonPropertyName("description")]
    [Display("Description")]
    public string? Description { get; set; }

    [JsonPropertyName("languages")]
    [Display("Languages")]
    public TaskLanguage[]? Languages { get; set; }

    [JsonPropertyName("auto_close_languages")]
    [Display("Auto close languages")]
    public bool? AutoCloseLanguages { get; set; }

    [JsonPropertyName("auto_close_task")]
    [Display("Auto close task")]
    public bool? AutoCloseTask { get; set; }

    [JsonPropertyName("auto_close_items")]
    [Display("Auto close items")]
    public bool? AutoCloseItems { get; set; }

    [JsonPropertyName("close_task")]
    [Display("Close task")]
    public bool? CloseTask { get; set; }

    [JsonPropertyName("closing_tags")]
    [Display("Closing tags")]
    public string[]? ClosingTags { get; set; }

    [JsonPropertyName("do_lock_translations")]
    [Display("Do lock translations")]
    public bool? DoLockTranslations { get; set; }
}