using System.Text.Json.Serialization;
using Apps.Lokalise.Models.Responses.Base;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class TasksWrapper : PaginationResponse<TaskResponse>
{
    [JsonPropertyName("tasks")]
    public override IEnumerable<TaskResponse> Items { get; set; }
}
