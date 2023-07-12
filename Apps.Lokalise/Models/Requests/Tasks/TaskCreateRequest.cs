namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskCreateRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string DueDate { get; set; }
    public string[] Keys { get; set; }
    public TaskLanguage[] Languages { get; set; }
    public string SourceLanguageIso { get; set; }
    public bool AutoCloseLanguage { get; set; }
    public bool AutoCloseTask { get; set; }
    public bool AutoCloseItems { get; set; }
    public string TaskType { get; set; }
    public string[] ClosingTags { get; set; }
    public bool DoLockTranslations { get; set; }
    public string[] CustomTranslationStatusIds { get; set; }
}
