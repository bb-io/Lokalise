using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class GetTaskRequest
{
    [Display("Project ID"), DataSource(typeof(ProjectDataHandler))]
    public string ProjectId { get; set; }
    
    [Display("Task ID"), DataSource(typeof(TaskDataHandler))]
    public string TaskId { get; set; }
}