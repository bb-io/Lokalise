using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Projects;

public class EmptyResponse
{
    [JsonProperty("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    [JsonProperty("keys_deleted")]
    [Display("Keys deleted")]
    public bool KeysDeleted { get; set; }
}
