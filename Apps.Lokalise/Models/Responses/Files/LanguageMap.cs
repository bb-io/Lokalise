using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Files;

public class LanguageMap
{
    [JsonProperty("original_language_iso")]
    [Display("Original language iso")]
    public string? OriginalLanguageIso { get; set; }

    [JsonProperty("custom_language_iso")]
    [Display("Custom language iso")]
    public string? CustomLanguageIso { get; set; }
}