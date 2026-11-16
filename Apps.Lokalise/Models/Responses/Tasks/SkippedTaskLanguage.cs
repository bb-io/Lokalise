using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class SkippedTaskLanguage
{
    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; } = string.Empty;

    [JsonProperty("reason")]
    [Display("Reason")]
    public string Reason { get; set; } = string.Empty;

    [JsonProperty("message")]
    [Display("Message")]
    public string? Message { get; set; }
}
