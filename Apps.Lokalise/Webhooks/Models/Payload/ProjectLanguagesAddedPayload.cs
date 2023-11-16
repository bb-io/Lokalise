using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;
// ProjectLanguagesAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectLanguagesAddedPayload : BasePayload>(myJsonResponse);

public class ProjectLanguagesAddedPayload : BasePayload
{
    [JsonProperty("languages")]
    public List<Language> Languages { get; set; }

    public override LanguagesEvent Convert()
    {
        return new LanguagesEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            Languages = Languages
        };
    }
}