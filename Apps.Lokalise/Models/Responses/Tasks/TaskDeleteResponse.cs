using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class TaskDeleteResponse
{
    [JsonPropertyName("project_id")]
    [Display("Project id")]
    public string ProjectId { get; set; }

    [JsonPropertyName("task_deleted")]
    [Display("Task deleted")]
    public bool TaskDeleted { get; set; }
}
