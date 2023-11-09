using Apps.Lokalise.Utils.Converters;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class TranslationObj
{
    [JsonProperty("translation_id")]
    [Display("Translation ID")]
    [JsonConverter(typeof(IntToStringConverter))]
    public string TranslationId { get; set; }

    [JsonProperty("key_id")]
    [Display("Key ID")]
    public string KeyId { get; set; }

    [JsonProperty("language_iso")]
    [Display("Language iso")]
    public string LanguageIso { get; set; }

    [JsonProperty("translation")] public string Translation { get; set; }

    [JsonProperty("modified_by")]
    [Display("Modified by")]
    public int ModifiedBy { get; set; }

    [JsonProperty("modified_by_email")]
    [Display("Modified by email")]
    public string ModifiedByEmail { get; set; }

    [JsonProperty("modified_at")]
    [Display("Modified at")]
    public string ModifiedAt { get; set; }

    [JsonProperty("modified_at_timestamp")]
    [Display("Modified at timestamp")]
    public int ModifiedAtTimestamp { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonProperty("is_unverified")]
    [Display("Is unreviewed")]
    public bool IsUnverified { get; set; }

    [JsonProperty("reviewed_by")]
    [Display("Reviewed by")]
    public int ReviewedBy { get; set; }

    [JsonProperty("words")] public int Words { get; set; }

    [JsonProperty("task_id")]
    [Display("Task ID")]
    public int? TaskId { get; set; }
}