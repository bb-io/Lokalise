namespace Apps.Lokalise.Models.Requests;
public class TaskLanguage
{
    public string LanguageIso { get; set; }
    public IEnumerable<string> Users { get; set; }
    public IEnumerable<string> Groups { get; set; }

}
