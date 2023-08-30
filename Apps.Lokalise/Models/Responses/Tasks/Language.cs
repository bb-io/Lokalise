using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class Language
{
    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("users")]
    [Display("Users")]
    public List<User> Users { get; set; }

    [JsonProperty("groups")]
    [Display("Groups")]
    public object Groups { get; set; }

    [JsonProperty("keys")]
    [Display("Keys")]
    public List<int> Keys { get; set; }

    [JsonProperty("status")]
    [Display("Status")]
    public string Status { get; set; }

    [JsonProperty("progress")]
    [Display("Progress")]
    public int Progress { get; set; }

    // [JsonProperty("initial_tm_leverage")]
    // [Display("Initial TM Leverage")]
    // public InitialTmLeverage InitialTmLeverage { get; set; }

    [JsonProperty("keys_count")]
    [Display("Keys count")]
    public int KeysCount { get; set; }

    [JsonProperty("words_count")]
    [Display("Words count")]
    public int WordsCount { get; set; }

    [JsonProperty("completed_at")]
    [Display("Completed at")]
    public string CompletedAt { get; set; }

    [JsonProperty("completed_at_timestamp")]
    [Display("Completed at timestamp")]
    public int? CompletedAtTimestamp { get; set; }

    [JsonProperty("completed_by")]
    [Display("Completed by")]
    public int? CompletedBy { get; set; }

    [JsonProperty("completed_by_email")]
    [Display("Completed by email")]
    public string CompletedByEmail { get; set; }
}
