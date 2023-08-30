using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectListParameters
{
    
    [JsonProperty("filter_team_id")]
    [Display("Filter team ID")]
    public string? FilterTeamId { get; set; }
    
    [JsonProperty("filter_names")]
    [Display("Filter names")]
    public string? FilterNames { get; set; }
    
    [JsonProperty("include_statistics")]
    [Display("Include statistics")]
    public bool? IncludeStatistics { get; set; }
    
    [JsonProperty("include_settings")]
    [Display("Include settings")]
    public bool? IncludeSettings { get; set; }
}
