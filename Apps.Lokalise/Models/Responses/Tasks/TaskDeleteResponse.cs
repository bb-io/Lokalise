using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class TaskDeleteResponse
{
    [JsonProperty("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }

    [JsonProperty("task_deleted")]
    [Display("Task deleted")]
    public bool TaskDeleted { get; set; }
}
