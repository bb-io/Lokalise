using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Projects;
public class ProjectDeleteResponse
{
    [JsonPropertyName("project_id")]
    [Display("Project id")]
    public string ProjectId { get; set; }
    
    [JsonPropertyName("project_deleted")]
    [Display("Project deleted")]
    public bool ProjectDeleted { get; set; }
}
