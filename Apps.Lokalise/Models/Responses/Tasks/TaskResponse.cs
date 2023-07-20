using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class TaskResponse
{
   [JsonPropertyName("task_id")]
    [Display("Task ID")]
    public int TaskId { get; set; }
    
    [JsonPropertyName("title")]
    [Display("Title")]
    public string Title { get; set; }
    
    [JsonPropertyName("can_be_parent")]
    [Display("Can be parent")]
    public bool CanBeParent { get; set; }
    
    [JsonPropertyName("task_type")]
    [Display("Task type")]
    public string TaskType { get; set; }
    
    [JsonPropertyName("parent_task_id")]
    [Display("Parent task ID")]
    public string ParentTaskId { get; set; }
    
    [JsonPropertyName("closing_tags")]
    [Display("Closing tags")]
    public string[] ClosingTags { get; set; }
    
    [JsonPropertyName("do_lock_translations")]
    [Display("Do lock translations")]
    public bool DoLockTranslations { get; set; }
    
    [JsonPropertyName("description")]
    [Display("Description")]
    public string Description { get; set; }
    
    [JsonPropertyName("status")]
    [Display("Status")]
    public string Status { get; set; }
    
    [JsonPropertyName("progress")]
    [Display("Progress")]
    public int Progress { get; set; }
    
    [JsonPropertyName("due_date")]
    [Display("Due date")]
    public string DueDate { get; set; }
    
    [JsonPropertyName("due_date_timestamp")]
    [Display("Due date timestamp")]
    public string DueDateTimestamp { get; set; }
    
    [JsonPropertyName("keys_count")]
    [Display("Keys count")]
    public int KeysCount { get; set; }
    
    [JsonPropertyName("words_count")]
    [Display("Words count")]
    public int WordsCount { get; set; }
    
    [JsonPropertyName("created_at")]
    [Display("Created at")]
    public string CreatedAt { get; set; }
    
    [JsonPropertyName("created_at_timestamp")]
    [Display("Created at timestamp")]
    public string CreatedAtTimestamp { get; set; }
    
    [JsonPropertyName("created_by")]
    [Display("Created by")]
    public string CreatedBy { get; set; }
    
    [JsonPropertyName("created_by_email")]
    [Display("Created by email")]
    public string CreatedByEmail { get; set; }
    
    [JsonPropertyName("languages")]
    [Display("Languages")]
    public Language[] Languages { get; set; }
    
    [JsonPropertyName("source_language_iso")]
    [Display("Source language code")]
    public string SourceLanguageIso { get; set; }
    
    [JsonPropertyName("auto_close_languages")]
    [Display("Auto close languages")]
    public bool AutoCloseLanguages { get; set; }
    
    [JsonPropertyName("auto_close_task")]
    [Display("Auto close task")]
    public bool AutoCloseTask { get; set; }
    
    [JsonPropertyName("auto_close_items")]
    [Display("Auto close items")]
    public bool AutoCloseItems { get; set; }
    
    [JsonPropertyName("completed_at")]
    [Display("Completed at")]
    public string CompletedAt { get; set; }
    
    [JsonPropertyName("completed_at_timestamp")]
    [Display("Completed at timestamp")]
    public string CompletedAtTimestamp { get; set; }
    
    [JsonPropertyName("completed_by")]
    [Display("Completed by")]
    public string CompletedBy { get; set; }
    
    [JsonPropertyName("completed_by_email")]
    [Display("Completed by email")]
    public string CompletedByEmail { get; set; }
    
    [JsonPropertyName("custom_translation_status_ids")]
    [Display("Custom translation status ids")]
    public string[] CustomTranslationStatusIds { get; set; }
}