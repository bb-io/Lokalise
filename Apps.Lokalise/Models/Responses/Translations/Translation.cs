using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Translations;

public class Translation
{
    [JsonProperty("translation_id")]
    [Display("Translation ID")]
    public int TranslationId { get; set; }

    [JsonProperty("key_id")]
    [Display("Key ID")]
    public int KeyId { get; set; }

    [JsonProperty("language_iso")]
    [Display("Language ISO")]
    public string LanguageIso { get; set; }

    [JsonProperty("modified_at")]
    [Display("Modified at")]
    public DateTime ModifiedAt { get; set; }

    [JsonProperty("modified_at_timestamp")]
    [Display("Modified at timestamp")]
    public int ModifiedAtTimestamp { get; set; }

    [JsonProperty("modified_by")]
    [Display("Modified by")]
    public int ModifiedBy { get; set; }

    [JsonProperty("modified_by_email")]
    [Display("Modified by email")]
    public string ModifiedByEmail { get; set; }

    [JsonProperty("translation")]
    [Display("Translation")]
    public string TranslationText { get; set; }

    [JsonProperty("is_unverified")]
    [Display("Is unverified")]
    public bool IsUnverified { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonProperty("reviewed_by")]
    [Display("Reviewed by")]
    public int ReviewedBy { get; set; }

    [JsonProperty("words")]
    [Display("Words")]
    public int Words { get; set; }

    [JsonProperty("task_id")]
    [Display("Task ID")]
    public int? TaskId { get; set; }

    [JsonProperty("segment_number")]
    [Display("Segment number")]
    public int SegmentNumber { get; set; }
}