using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectUpdateRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
