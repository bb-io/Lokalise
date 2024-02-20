using Apps.Lokalise.Models.Responses.Tasks;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class GetTaskLanguageResponse : GetTaskResponse
{
    [Display("Language ID")]
    public string LanguageId { get; set; }

    [Display("Language code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string LanguageName { get; set; }
    
    public GetTaskLanguageResponse(GetTaskResponse response, TaskLanguageEvent taskLanguageEvent) : base(response.ProjectId, response.Task)
    {
        LanguageId = taskLanguageEvent.LanguageId;
        Iso = taskLanguageEvent.Iso;
        LanguageName = taskLanguageEvent.LanguageName;
    }
}