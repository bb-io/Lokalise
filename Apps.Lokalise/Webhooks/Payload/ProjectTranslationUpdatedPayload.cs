using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationUpdatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTranslationUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationUpdatedPayload : BasePayload
    {
        [JsonPropertyName("translation")] public TranslationUpdated Translation { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
        [JsonPropertyName("language")] public Language Language { get; set; }

        public override TranslationEvent Convert()
        {
            return new TranslationEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                LanguageId = Language.Id,
                Iso = Language.Iso,
                LanguageName = Language.Name,
                KeyId = Key.Id,
                KeyName = Key.Name,
                TranslationId = Translation.Id,
                TranslationValue = Translation.Value,
                PreviousTranslationValue = Translation.PreviousValue
            };
        }
    }

    public class TranslationUpdated
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }

        [JsonPropertyName("previous_value")]
        [Display("Previous value")]
        public string PreviousValue { get; set; }
    }
}