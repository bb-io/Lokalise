using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class SegmentDto
    {
        [JsonPropertyName("segment_number")]
        [Display("Segment number")]
        public int SegmentNumber { get; set; }

        [JsonPropertyName("language_iso")]
        [Display("Language iso")]
        public string LanguageIso { get; set; }

        [JsonPropertyName("modified_at")]
        [Display("Modified at")]
        public string ModifiedAt { get; set; }

        [JsonPropertyName("modified_by_email")]
        [Display("Modified by email")]
        public string ModifiedByEmail { get; set; }

        [JsonPropertyName("value")] public string Value { get; set; }

        [JsonPropertyName("is_fuzzy")]
        [Display("Is fuzzy")]
        public bool IsFuzzy { get; set; }

        [JsonPropertyName("is_reviewed")]
        [Display("Is reviewed")]
        public bool IsReviewed { get; set; }

        [JsonPropertyName("words")] public int Words { get; set; }
    }
}