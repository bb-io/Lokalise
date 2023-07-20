using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageRemovedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectLanguageRemovedPayload : BasePayload>(myJsonResponse);
    public class Language
    {
        [JsonPropertyName("id")]
        [Display("Language ID")]
        public int Id { get; set; }

        [JsonPropertyName("iso")]
        [Display("ISO code")]
        public string Iso { get; set; }

        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class ProjectLanguageRemovedPayload : BasePayload
    {
        [JsonPropertyName("language")] public Language Language { get; set; }

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