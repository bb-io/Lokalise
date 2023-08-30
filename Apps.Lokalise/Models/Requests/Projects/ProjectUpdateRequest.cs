using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectUpdateRequest
{
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("description")]
    public string? Description { get; set; }
}
