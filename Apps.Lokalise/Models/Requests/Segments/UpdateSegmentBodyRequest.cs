using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Segments;

public class UpdateSegmentBodyRequest
{
    [JsonPropertyName("value")] public string Value { get; set; }

    [JsonPropertyName("is_fuzzy")]
    [Display("Is fuzzy")]
    public bool? IsFuzzy { get; set; }

    [JsonPropertyName("is_reviewed")]
    [Display("Is reviewed")]
    public bool? IsReviewed { get; set; }

    [JsonPropertyName("custom_translation_status_ids")]
    [Display("Custom translation status ids")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
}