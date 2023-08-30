using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;
public class TaskListParameters
{
    [JsonProperty("filter_title")]
    [Display("Filter title")]
    public string? FilterTitle { get; set; }

    [JsonProperty("filter_statuses")]
    [Display("Filter statuses")]
    [DataSource(typeof(TaskStatusDataHandler))]
    public string? FilterStatuses { get; set; }
}
