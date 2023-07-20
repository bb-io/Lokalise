using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Projects;

public class ProjectResponse
{
    [JsonPropertyName("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    [JsonPropertyName("project_type")]
    [Display("Project type")]
    public string ProjectType { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("created_at")]
    [Display("Created at")]
    public string CreatedAt { get; set; }
    
    [JsonPropertyName("created_at_timestamp")]
    [Display("Created at timestamp")]
    public int CreatedAtTimestamp { get; set; }
    
    [JsonPropertyName("created_by")]
    [Display("Created by")]
    public int CreatedBy { get; set; }
    
    [JsonPropertyName("created_by_email")]
    [Display("Created by email")]
    public string CreatedByEmail { get; set; }
    
    [JsonPropertyName("team_id")]
    [Display("Team ID")]
    public int TeamId { get; set; }
    
    [JsonPropertyName("base_language_id")]
    [Display("Base language ID")]
    public int BaseLanguageId { get; set; }
    
    [JsonPropertyName("base_language_iso")]
    [Display("Base language iso")]
    public string BaseLanguageIso { get; set; }
}