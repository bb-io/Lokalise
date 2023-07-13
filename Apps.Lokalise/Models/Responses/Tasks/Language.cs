using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class Language
{
    [JsonPropertyName("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonPropertyName("users")]
    [Display("Users")]
    public List<User> Users { get; set; }

    [JsonPropertyName("groups")]
    [Display("Groups")]
    public object Groups { get; set; }

    [JsonPropertyName("keys")]
    [Display("Keys")]
    public List<int> Keys { get; set; }

    [JsonPropertyName("status")]
    [Display("Status")]
    public string Status { get; set; }

    [JsonPropertyName("progress")]
    [Display("Progress")]
    public int Progress { get; set; }

    // [JsonPropertyName("initial_tm_leverage")]
    // [Display("Initial TM Leverage")]
    // public InitialTmLeverage InitialTmLeverage { get; set; }

    [JsonPropertyName("keys_count")]
    [Display("Keys count")]
    public int KeysCount { get; set; }

    [JsonPropertyName("words_count")]
    [Display("Words count")]
    public int WordsCount { get; set; }

    [JsonPropertyName("completed_at")]
    [Display("Completed at")]
    public string CompletedAt { get; set; }

    [JsonPropertyName("completed_at_timestamp")]
    [Display("Completed at timestamp")]
    public int? CompletedAtTimestamp { get; set; }

    [JsonPropertyName("completed_by")]
    [Display("Completed by")]
    public int? CompletedBy { get; set; }

    [JsonPropertyName("completed_by_email")]
    [Display("Completed by email")]
    public string CompletedByEmail { get; set; }
}
