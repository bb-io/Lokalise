using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Keys;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class GetKeyEvent : BaseEvent
{
    public KeyDto Key { get; set; }
    
    public GetKeyEvent(string projectId, string projectName, string userName, string userEmail, KeyResponse keyResponse)
    {
        ProjectId = projectId;
        ProjectName = projectName;
        UserName = userName;
        UserEmail = userEmail;
        Key = keyResponse.Key;
    }

    public GetKeyEvent(KeyEvent keyEvent, KeyResponse keyResponse)
    {
        ProjectId = keyEvent.ProjectId;
        ProjectName = keyEvent.ProjectName;
        UserName = keyEvent.UserName;
        UserEmail = keyEvent.UserEmail;
        Key = keyResponse.Key;
    }
}