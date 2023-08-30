using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Projects;
public class ProjectDeleteResponse
{
    [JsonProperty("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    [JsonProperty("project_deleted")]
    [Display("Project deleted")]
    public bool ProjectDeleted { get; set; }
}
