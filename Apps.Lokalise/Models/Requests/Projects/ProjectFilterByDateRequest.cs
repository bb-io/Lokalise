namespace Apps.Lokalise.Models.Requests.Projects;

public class ProjectFilterByDateRequest : ProjectListParameters
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
}