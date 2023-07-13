using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskListParameters
{
    [JsonPropertyName("filter_title")]
    [Display("Filter title")]
    public string? FilterTitle { get; set; }

    [JsonPropertyName("filter_statuses")]
    [Display("Filter statuses")]
    public string? FilterStatuses { get; set; }
}
