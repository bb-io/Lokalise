using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectLanguage
{
    [JsonProperty("lang_iso")]
    public string LangIso { get; set; }
    
    [JsonProperty("custom_iso")]
    public string? CustomIso { get; set; }
}
