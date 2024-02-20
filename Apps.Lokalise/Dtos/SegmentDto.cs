using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class SegmentDto
{
    [JsonProperty("segment_number")]
    [Display("Segment number")]
    public int SegmentNumber { get; set; }

    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("modified_at")]
    [Display("Modified at")]
    public string ModifiedAt { get; set; }

    [JsonProperty("modified_by_email")]
    [Display("Modified by email")]
    public string ModifiedByEmail { get; set; }

    [JsonProperty("value")] public string Value { get; set; }

    [JsonProperty("is_fuzzy")]
    [Display("Is fuzzy")]
    public bool IsFuzzy { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonProperty("words")] public int Words { get; set; }
}