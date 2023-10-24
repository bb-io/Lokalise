using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class BaseEvent
{
    [Display("Project ID")] public string ProjectId { get; set; }

    [Display("Project name")] public string ProjectName { get; set; }

    [Display("User email")] public string UserEmail { get; set; }

    [Display("User name")] public string UserName { get; set; }

    public BaseEvent(BaseEvent @event)
    {
        ProjectId = @event.ProjectId;
        ProjectName = @event.ProjectName;
        UserEmail = @event.UserEmail;
        UserName = @event.UserName;
    }

    public BaseEvent()
    {
    }
}