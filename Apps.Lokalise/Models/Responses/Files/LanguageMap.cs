using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Files;

public class LanguageMap
{
    [JsonPropertyName("original_language_iso")]
    [Display("Original language iso")]
    public string? OriginalLanguageIso { get; set; }

    [JsonPropertyName("custom_language_iso")]
    [Display("Custom language iso")]
    public string? CustomLanguageIso { get; set; }
}