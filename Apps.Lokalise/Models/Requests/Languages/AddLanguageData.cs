using System.Text.Json.Serialization;
using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageData
{
    [JsonPropertyName("lang_iso")] 
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; }
    
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