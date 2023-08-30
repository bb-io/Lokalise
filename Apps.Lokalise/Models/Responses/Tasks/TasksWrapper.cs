using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class TasksWrapper : PaginationResponse<TaskResponse>
{
    [JsonProperty("tasks")]
    public override IEnumerable<TaskResponse> Items { get; set; }
}
