using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class TaskRetriveResponse
{
    [JsonPropertyName("task")]
    public TaskResponse Task { get; set; }
}
