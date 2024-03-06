using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Translations;

public class Translation
{
    [JsonProperty("translation_id")]
    [Display("Translation ID")]
    public string TranslationId { get; set; }

    [JsonProperty("key_id")]
    [Display("Key ID")]
    public string KeyId { get; set; }

    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("translation")]
    [Display("Translation text")]
    public string TranslationText { get; set; }

    [JsonProperty("is_unverified")]
    [Display("Is unverified")]
    public bool IsUnverified { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonProperty("task_id")]
    [Display("Task ID")]
    public string? TaskId { get; set; }
}