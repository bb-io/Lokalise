using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Segments;

public class UpdateSegmentBodyRequest
{
    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("is_fuzzy")]
    [Display("Is fuzzy")]
    public bool? IsFuzzy { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool? IsReviewed { get; set; }

    [JsonProperty("custom_translation_status_ids")]
    [Display("Custom translation status ids")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
}