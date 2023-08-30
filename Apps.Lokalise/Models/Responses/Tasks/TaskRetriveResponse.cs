using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class TaskRetriveResponse
{
    [JsonProperty("task")]
    public TaskResponse Task { get; set; }
}
