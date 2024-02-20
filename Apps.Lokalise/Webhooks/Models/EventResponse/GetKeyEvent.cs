using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Keys;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class GetKeyEvent
{
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    public KeyDto Key { get; set; }
    
    public GetKeyEvent(string projectId, KeyResponse keyResponse)
    {
        ProjectId = projectId;
        Key = keyResponse.Key;
    }
}