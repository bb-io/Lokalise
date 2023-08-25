using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskUpdateRequest
{
    [JsonProperty("title")]
    [Display("Title")]
    public string? Title { get; set; }

    [JsonProperty("due_date")]
    [Display("Due date")]
    public string? DueDate { get; set; }

    [JsonProperty("description")]
    [Display("Description")]
    public string? Description { get; set; }

    [JsonProperty("languages")]
    [Display("Languages")]
    public TaskLanguage[]? Languages { get; set; }

    [JsonProperty("auto_close_languages")]
    [Display("Auto close languages")]
    public bool? AutoCloseLanguages { get; set; }

    [JsonProperty("auto_close_task")]
    [Display("Auto close task")]
    public bool? AutoCloseTask { get; set; }

    [JsonProperty("auto_close_items")]
    [Display("Auto close items")]
    public bool? AutoCloseItems { get; set; }

    [JsonProperty("close_task")]
    [Display("Close task")]
    public bool? CloseTask { get; set; }

    [JsonProperty("closing_tags")]
    [Display("Closing tags")]
    public string[]? ClosingTags { get; set; }

    [JsonProperty("do_lock_translations")]
    [Display("Do lock translations")]
    public bool? DoLockTranslations { get; set; }
}