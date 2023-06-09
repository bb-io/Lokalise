using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationsUpdatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTranslationsUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationsUpdatedPayload : BasePayload
    {
        [JsonPropertyName("translations")] public List<TranslationsUpdated> Translations { get; set; }

        public override TranslationsEvent Convert()
        {
            return new TranslationsEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Translations = Translations.Select(x => new Models.Translation
                {
                    LanguageId = x.Language.Id,
                    Iso = x.Language.Iso,
                    LanguageName = x.Language.Name,
                    KeyId = x.Key.Id,
                    KeyName = x.Key.Name,
                    TranslationId = x.Id,
                    TranslationValue = x.Value,
                    PreviousTranslationValue = x.PreviousValue
                }).ToList(),
            };
        }
    }

    public class TranslationsUpdated
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }

        [JsonPropertyName("previous_value")]
        [Display("Previous value")]
        public string PreviousValue { get; set; }

        [JsonPropertyName("language")] public Language Language { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
    }
}