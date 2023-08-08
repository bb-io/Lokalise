using System.Text.Json.Serialization;
using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskListParameters
{
    [JsonPropertyName("filter_title")]
    [Display("Filter title")]
    public string? FilterTitle { get; set; }

    [JsonPropertyName("filter_statuses")]
    [Display("Filter statuses")]
    [DataSource(typeof(TaskStatusDataHandler))]
    public string? FilterStatuses { get; set; }
}
