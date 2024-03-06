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
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("translation")]
    [Display("Text")]
    public string Translation { get; set; }

    [JsonProperty("is_reviewed")]
    [Display("Is reviewed")]
    public bool IsReviewed { get; set; }

    [JsonProperty("is_unverified")]
    [Display("Is unreviewed")]
    public bool IsUnverified { get; set; }

    [JsonProperty("task_id")]
    [Display("Task ID")]
    public int? TaskId { get; set; }
}