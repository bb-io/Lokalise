using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class GetTaskEvent : BaseEvent
{
    public TaskResponse Task { get; set; }
    
    public GetTaskEvent(TaskEvent taskEvent, TaskResponse task)
    {
        ProjectId = taskEvent.ProjectId;
        ProjectName = taskEvent.ProjectName;
        UserName = taskEvent.UserName;
        UserEmail = taskEvent.UserEmail;
        Task = task;
    }
}