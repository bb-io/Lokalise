using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;
// ProjectTaskLanguageClosedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskLanguageClosedPayload : BasePayload>(myJsonResponse);

public class ProjectTaskLanguageClosedPayload : TaskPayload
{
    [JsonProperty("language")]
    public Language Language { get; set; }

    public override TaskLanguageEvent Convert()
    {
        return new TaskLanguageEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            TaskId = Task.Id,
            Title = Task.Title,
            Description = Task.Description,
            LanguageId= Language.Id,
            Iso = Language.Iso,
            LanguageName = Language.Name
        };
    }
}