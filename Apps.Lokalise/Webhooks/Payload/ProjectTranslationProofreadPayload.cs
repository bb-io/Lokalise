using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationProofreadPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTranslationProofreadPayload : BasePayload>(myJsonResponse);
    public class KeyName
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("name")] public string Name { get; set; }
    }

    public class ProjectTranslationProofreadPayload : BasePayload
    {
        [JsonPropertyName("translation")] public Translation Translation { get; set; }
        [JsonPropertyName("key")] public KeyName Key { get; set; }
        [JsonPropertyName("language")] public Language Language { get; set; }

        public override ProofreadEvent Convert()
        {
            return new ProofreadEvent
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
                IsProofread = Translation.IsProofread
            };
        }
    }

    public class Translation
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("value")] public string Value { get; set; }

        [JsonPropertyName("is_proofread")]
        [Display("Is proofread")]
        public bool IsProofread { get; set; }
    }
}