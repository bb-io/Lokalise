using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectTranslationProofreadPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTranslationProofreadPayload : BasePayload>(myJsonResponse);
public class KeyName
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("name")] public string Name { get; set; }
}

public class ProjectTranslationProofreadPayload : BasePayload
{
    [JsonProperty("translation")] public Translation Translation { get; set; }
    [JsonProperty("key")] public KeyName Key { get; set; }
    [JsonProperty("language")] public Language Language { get; set; }

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
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("is_proofread")]
    [Display("Is proofread")]
    public bool IsProofread { get; set; }
}