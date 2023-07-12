using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos;

public class TranslationObj
{
    [JsonPropertyName("translation_id")]
    [Display("Translation id")]
    public long TranslationId { get; set; }

    [JsonPropertyName("key_id")]
    [Display("Key id")]
    public int KeyId { get; set; }

    [JsonPropertyName("language_iso")]
    [Display("Language iso")]
    public string LanguageIso { get; set; }

    [JsonPropertyName("translation")] public string Translation { get; set; }

    [JsonPropertyName("modified_by")]
    [Display("Modified by")]
    public int ModifiedBy { get; set; }

    [JsonPropertyName("modified_by_email")]
    [Display("Modified by email")]
    public string ModifiedByEmail { get; set; }

    [JsonPropertyName("modified_at")]
    [Display("Modified at")]
    public string ModifiedAt { get; set; }

    [JsonPropertyName("modified_at_timestamp")]
    [Display("Modified at timestamp")]
    public int ModifiedAtTimestamp { get; set; }

    [JsonPropertyName("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonPropertyName("is_unreviewed")]
    [Display("Is unreviewed")]
    public bool IsUnverified { get; set; }

    [JsonPropertyName("reviewed_by")]
    [Display("Reviewed by")]
    public int ReviewedBy { get; set; }

    [JsonPropertyName("words")] public int Words { get; set; }

    [JsonPropertyName("task_id")]
    [Display("Task id")]
    public int? TaskId { get; set; }
}