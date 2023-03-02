namespace Apps.Lokalise.Models.Responses.Projects;

public class Language
{
    public int LanguageId { get; set; }
    public string LanguageIso { get; set; }
    public int Progress { get; set; }
    public int WordsToDo { get; set; }
}