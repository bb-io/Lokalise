using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageData
{
    [JsonProperty("lang_iso")]
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; }

    [JsonProperty("custom_iso")] public string? CustomIso { get; set; }
    [JsonProperty("custom_name")] public string? CustomName { get; set; }

    [JsonProperty("custom_plural_forms")] public IEnumerable<string>? CustomPluralForms { get; set; }
}