using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskClosedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskClosedPayload : BasePayload
    {
        [JsonPropertyName("task")] public Task Task { get; set; }
    }

    public class Task
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; }

        [JsonPropertyName("due_date")]
        [Display("Due date")]
        public DateTime DueDate { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
    }
}