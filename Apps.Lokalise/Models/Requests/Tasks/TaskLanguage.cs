using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskLanguage
{
    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("users")]
    [Display("Users")]
    public IEnumerable<string>? Users { get; set; }

    [JsonProperty("groups")]
    [Display("Groups")]
    public IEnumerable<string>? Groups { get; set; }

}
