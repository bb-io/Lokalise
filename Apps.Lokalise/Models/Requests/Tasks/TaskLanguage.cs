using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskLanguage
{
    [JsonPropertyName("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonPropertyName("users")]
    [Display("Users")]
    public string[] Users { get; set; }

    [JsonPropertyName("groups")]
    [Display("Groups")]
    public string[] Groups { get; set; }

}
