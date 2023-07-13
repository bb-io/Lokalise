using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects;
public class ProjectListParameters
{
    
    [JsonPropertyName("filter_team_id")]
    [Display("Filter team id")]
    public string? FilterTeamId { get; set; }
    
    [JsonPropertyName("filter_names")]
    [Display("Filter names")]
    public string? FilterNames { get; set; }
    
    [JsonPropertyName("include_statistics")]
    [Display("Include statistics")]
    public bool? IncludeStatistics { get; set; }
    
    [JsonPropertyName("include_settings")]
    [Display("Include settings")]
    public bool? IncludeSettings { get; set; }
}
