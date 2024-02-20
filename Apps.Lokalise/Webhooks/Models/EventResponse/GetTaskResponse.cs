using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class GetTaskResponse
{
    [Display("Project ID")]
    public string ProjectId { get; set; }

    public TaskResponse Task { get; set; }
    
    public GetTaskResponse(string projectId, TaskResponse task)
    {
        ProjectId = projectId;
        Task = task;
    }
}