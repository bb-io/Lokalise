using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload;

// ProjectLanguageRemovedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectLanguageRemovedPayload : BasePayload>(myJsonResponse);
public class Language
{
    [JsonProperty("id")]
    [Display("Language ID")]
    public int Id { get; set; }

    [JsonProperty("iso")]
    [Display("ISO code")]
    public string Iso { get; set; }

    [JsonProperty("name")] public string Name { get; set; }
}

public class ProjectLanguageRemovedPayload : BasePayload
{
    [JsonProperty("language")] public Language Language { get; set; }

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