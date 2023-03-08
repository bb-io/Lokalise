namespace Apps.Lokalise.Models.Responses.Tasks;
public class TaskResponse
{
    public int TaskId { get; set; }
    public string Title { get; set; }
    public bool CanBeParent { get; set; }
    public string TaskType { get; set; }
    public string ParentTaskId { get; set; }
    public string[] ClosingTags { get; set; }
    public bool DoLockTranslations { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public int Progress { get; set; }
    public string DueDate { get; set; }
    public string DueDateTimestamp { get; set; }
    public int KeysCount { get; set; }
    public int WordsCount { get; set; }
    public string CreatedAt { get; set; }
    public string CreatedAtTimestamp { get; set; }
    public string CreatedBy { get; set; }
    public string CreatedByEmail { get; set; }
    public Language[] Languages { get; set; }
    public string SourceLanguageIso { get; set; }
    public bool AutoCloseLanguages { get; set; }
    public bool AutoCloseTask { get; set; }
    public bool AutoCloseItems { get; set; }
    public string CompletedAt { get; set; }
    public string CompletedAtTimestamp { get; set; }
    public string CompletedBy { get; set; }
    public string CompletedByEmail { get; set; }
    public string[] CustomTranslationStatusIds { get; set; }
}