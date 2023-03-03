namespace Apps.Lokalise.Models.Requests;
public class TaskUpdateRequest
{
    public string Title { get; set; }
    public string DueDate { get; set; }
    public string Description { get; set; }
    public TaskLanguage[] Languages { get; set; }
    public bool AutoCloseLanguages { get; set; }
    public bool AutoCloseTask { get; set; }
    public bool AutoCloseItems { get; set; }
    public bool CloseTask { get; set; }
    public string[] ClosingTags { get; set; }
    public bool DoLockTranslations { get; set; }
}
