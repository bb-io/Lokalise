namespace Apps.Lokalise.Models.Responses.Projects;
public class Statistics
{
    public int ProgressTotal { get; set; }
    public int KeysTotal { get; set; }
    public int Team { get; set; }
    public int BaseWords { get; set; }
    public int QaIssuesTotal { get; set; }
    //public QaIssues QaIssues { get; set; }
    public List<Language> Languages { get; set; }
}
