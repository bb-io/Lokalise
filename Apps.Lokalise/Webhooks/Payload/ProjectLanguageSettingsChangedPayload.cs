using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageSettings_changedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectLanguageSettings_changedPayload : BasePayload>(myJsonResponse);
    public class ProjectLanguageSettingsChangedPayload : BasePayload
    {
        [JsonPropertyName("language")]
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


}