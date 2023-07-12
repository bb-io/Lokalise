using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageData
{
    [JsonPropertyName("lang_iso")] public string LanguageCode { get; set; }
    [JsonPropertyName("custom_iso")] public string? CustomIso { get; set; }
    [JsonPropertyName("custom_name")] public string? CustomName { get; set; }

    [JsonPropertyName("custom_plural_forms")]
    public IEnumerable<string>? CustomPluralForms { get; set; }

    public AddLanguageData(AddLanguageToProjectInput input)
    {
        LanguageCode = input.LanguageCode;
        CustomIso = input.CustomIso;
        CustomName = input.CustomName;
        CustomPluralForms = input.CustomPluralForms;
    }
}