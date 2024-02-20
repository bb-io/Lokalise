using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectTranslationUpdatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTranslationUpdatedPayload : BasePayload>(myJsonResponse);
public class ProjectTranslationUpdatedPayload : BasePayload
{
    [JsonProperty("translation")] public TranslationUpdated Translation { get; set; }
    [JsonProperty("key")] public KeyName Key { get; set; }
    [JsonProperty("language")] public Language Language { get; set; }

    public override TranslationEvent Convert()
    {
        return new TranslationEvent(Key.Id)
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            LanguageId = Language.Id,
            Iso = Language.Iso,
            LanguageName = Language.Name,
            KeyName = Key.Name,
            TranslationId = Translation.Id,
            TranslationValue = Translation.Value,
            PreviousTranslationValue = Translation.PreviousValue
        };
    }
}

public class TranslationUpdated
{
    [JsonProperty("id")] public string Id { get; set; }
    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("previous_value")]
    [Display("Previous value")]
    public string PreviousValue { get; set; }
}