using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Projects;

public class EmptyResponse
{
    [JsonPropertyName("project_id")]
    [Display("Project id")]
    public string ProjectId { get; set; }
    
    [JsonPropertyName("keys_deleted")]
    [Display("Keys deleted")]
    public bool KeysDeleted { get; set; }
}
