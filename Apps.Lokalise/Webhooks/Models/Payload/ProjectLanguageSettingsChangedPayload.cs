using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectLanguageSettings_changedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectLanguageSettings_changedPayload : BasePayload>(myJsonResponse);
public class ProjectLanguageSettingsChangedPayload : BasePayload
{
    [JsonProperty("language")]
    public Language Language { get; set; }

    public override LanguageEvent Convert()
    {
        return new LanguageEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            Id = Language.Id,
            Iso = Language.Iso,
            Name = Language.Name
        };
    }
}