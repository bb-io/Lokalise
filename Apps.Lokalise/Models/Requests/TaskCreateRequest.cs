namespace Apps.Lokalise.Models.Requests;
public class TaskCreateRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public IEnumerable<string> Keys { get; set; }
    public IEnumerable<TaskLanguage> Languages { get; set; }
    public string SourceLanguageIso { get; set; }
    public bool AutoCloseLanguage { get; set; }
    public bool AutoCloseTask { get; set; }
    public bool AutoCloseItems { get; set; }
    public string TaskType { get; set; }
    public IEnumerable<string> ClosingTags { get; set; }
    public bool DoLockTranslations { get; set; }
    public IEnumerable<string> CustomTranslationStatusIds { get; set; }
}
