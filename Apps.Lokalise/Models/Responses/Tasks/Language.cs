namespace Apps.Lokalise.Models.Responses.Tasks;
public class Language
{
    public string LanguageIso { get; set; }
    public List<User> Users { get; set; }
    public object Groups { get; set; }
    public List<int> Keys { get; set; }
    public string Status { get; set; }
    public int Progress { get; set; }
    public InitialTmLeverage InitialTmLeverage { get; set; }
    public int KeysCount { get; set; }
    public int WordsCount { get; set; }
    public string CompletedAt { get; set; }
    public int? CompletedAtTimestamp { get; set; }
    public int? CompletedBy { get; set; }
    public string CompletedByEmail { get; set; }
}
