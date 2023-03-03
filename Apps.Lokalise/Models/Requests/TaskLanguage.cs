namespace Apps.Lokalise.Models.Requests;
public class TaskLanguage
{
    public string LanguageIso { get; set; }
    public string[] Users { get; set; }
    public string[] Groups { get; set; }

}
