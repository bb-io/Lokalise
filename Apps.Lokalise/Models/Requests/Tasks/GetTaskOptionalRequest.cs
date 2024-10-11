using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class GetTaskOptionalRequest : ProjectOptionalRequest
{
    [Display("Task ID"), DataSource(typeof(TaskDataHandler))]
    public string? TaskId { get; set; }
}