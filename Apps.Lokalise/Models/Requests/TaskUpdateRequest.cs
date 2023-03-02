namespace Apps.Lokalise.Models.Requests;
public class TaskUpdateRequest
{
    public string Title { get; set; }
    public string DueDate { get; set; }
    public string Description { get; set; }
    public IEnumerable<TaskLanguage> Languages { get; set; }
    public bool AutoCloseLanguages { get; set; }
    public bool AutoCloseTask { get; set; }
    public bool AutoCloseItems { get; set; }
    public bool CloseTask { get; set; }
    public IEnumerable<string> ClosingTags { get; set; }
    public bool DoLockTranslations { get; set; }
}
