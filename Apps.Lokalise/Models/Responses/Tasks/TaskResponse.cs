using Apps.Lokalise.Utils.Converters;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class TaskResponse
{
    [JsonProperty("task_id")]
    [Display("Task ID")]
    public string TaskId { get; set; }

    [JsonProperty("title")]
    [Display("Title")]
    public string Title { get; set; }

    [JsonProperty("can_be_parent")]
    [Display("Can be parent")]
    public bool CanBeParent { get; set; }

    [JsonProperty("task_type")]
    [Display("Task type")]
    public string TaskType { get; set; }

    [JsonProperty("parent_task_id")]
    [Display("Parent task ID")]
    public string ParentTaskId { get; set; }

    [JsonProperty("closing_tags")]
    [Display("Closing tags")]
    public string[] ClosingTags { get; set; }

    [JsonProperty("do_lock_translations")]
    [Display("Do lock translations")]
    public bool DoLockTranslations { get; set; }

    [JsonProperty("description")]
    [Display("Description")]
    public string Description { get; set; }

    [JsonProperty("status")]
    [Display("Status")]
    public string Status { get; set; }

    [JsonProperty("progress")]
    [Display("Progress")]
    public int Progress { get; set; }

    [JsonProperty("due_date")]
    [Display("Due date")]
    [JsonConverter(typeof(LokaliseDateTimeConverter))]
    public DateTime DueDate { get; set; }

    [JsonProperty("due_date_timestamp")]
    [Display("Due date timestamp")]
    public string DueDateTimestamp { get; set; }

    [JsonProperty("keys_count")]
    [Display("Keys count")]
    public int KeysCount { get; set; }

    [JsonProperty("words_count")]
    [Display("Words count")]
    public int WordsCount { get; set; }

    [JsonProperty("created_at")]
    [Display("Created at")]
    public DateTime CreatedAt { get; set; }

    [JsonProperty("created_at_timestamp")]
    [Display("Created at timestamp")]
    public string CreatedAtTimestamp { get; set; }

    [JsonProperty("created_by")]
    [Display("Created by")]
    public string CreatedBy { get; set; }

    [JsonProperty("created_by_email")]
    [Display("Created by email")]
    public string CreatedByEmail { get; set; }

    [JsonProperty("languages")]
    [Display("Languages")]
    public Language[] Languages { get; set; }

    [Display("Users")]
    public IEnumerable<User> UserIds
        => Languages.SelectMany(x => x.Users).Distinct();

    [JsonProperty("source_language_iso")]
    [Display("Source language code")]
    public string SourceLanguageIso { get; set; }

    [JsonProperty("auto_close_languages")]
    [Display("Auto close languages")]
    public bool AutoCloseLanguages { get; set; }

    [JsonProperty("auto_close_task")]
    [Display("Auto close task")]
    public bool AutoCloseTask { get; set; }

    [JsonProperty("auto_close_items")]
    [Display("Auto close items")]
    public bool AutoCloseItems { get; set; }

    [JsonProperty("completed_at")]
    [Display("Completed at")]
    [JsonConverter(typeof(LokaliseDateTimeConverter))]
    public DateTime CompletedAt { get; set; }

    [JsonProperty("completed_at_timestamp")]
    [Display("Completed at timestamp")]
    public string CompletedAtTimestamp { get; set; }

    [JsonProperty("completed_by")]
    [Display("Completed by")]
    public string CompletedBy { get; set; }

    [JsonProperty("completed_by_email")]
    [Display("Completed by email")]
    public string CompletedByEmail { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    [Display("Custom translation status ids")]
    public string[] CustomTranslationStatusIds { get; set; }


    [Display("Language codes")] public List<string> LanguageCodes { get; set; }

    public void FillLanguageCodesArray()
    {
        LanguageCodes = Languages.Select(l => l.LanguageIso).ToList();
    }
}