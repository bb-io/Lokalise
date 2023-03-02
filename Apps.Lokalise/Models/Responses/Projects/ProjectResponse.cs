namespace Apps.Lokalise.Models.Responses.Projects;

public class ProjectResponse
{
    public string ProjectId { get; set; }
    public string ProjectType { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string CreatedAt { get; set; }
    public int CreatedAtTimestamp { get; set; }
    public int CreatedBy { get; set; }
    public string CreatedByEmail { get; set; }
    public int TeamId { get; set; }
    public int BaseLanguageId { get; set; }
    public string BaseLanguageIso { get; set; }
    public Settings Settings { get; set; }
    public Statistics Statistics { get; set; }
}