using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Apps.Lokalise.Models.Responses.Projects;

public class ProjectResponse
{
    [JsonProperty("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    [JsonProperty("project_type")]
    [Display("Project type")]
    public string ProjectType { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("created_at")]
    [Display("Created at")]
    public string CreatedAt { get; set; }
    
    [JsonProperty("created_at_timestamp")]
    [Display("Created at timestamp")]
    public int CreatedAtTimestamp { get; set; }
    
    [JsonProperty("created_by")]
    [Display("Created by")]
    public int CreatedBy { get; set; }
    
    [JsonProperty("created_by_email")]
    [Display("Created by email")]
    public string CreatedByEmail { get; set; }
    
    [JsonProperty("team_id")]
    [Display("Team ID")]
    public string TeamId { get; set; }
    
    [JsonProperty("base_language_id")]
    [Display("Base language ID")]
    public string BaseLanguageId { get; set; }
    
    [JsonProperty("base_language_iso")]
    [Display("Base language iso")]
    public string BaseLanguageIso { get; set; }

    [Display("Target languages")]
    public List<string> TargetLanguages { get; set; }

    [JsonProperty("statistics")]
    [Display("Statistics")]
    public ProjectStatisticsDto Statistics { get; set; }


    [OnDeserialized]
    internal void OnDeserializedMethod(StreamingContext context)
    {
        TargetLanguages = Statistics.Languages.Where(l => l.LanguageIso != BaseLanguageIso).Select(l => l.LanguageIso).ToList();
    }
}