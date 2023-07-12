namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectCreateRequest
{
    public string Name { get; set; }
    public int TeamId { get; set; }
    public string Description { get; set; }
    public ProjectLanguage[] Languages { get; set; }
    public string BaseLangIso { get; set; }
    public string ProjectType { get; set; }
    public bool IsSegmentationEnabled { get; set; }
}
