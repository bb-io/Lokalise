using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskClosedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskClosedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskClosedPayload : BasePayload
    {
        [JsonPropertyName("task")] public Task Task { get; set; }

        public override TaskEvent Convert()
        {
            return new TaskEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                TaskId = Task.Id,
                Title = Task.Title,
                //DueDate = Task.Due_date,
                Description = Task.Description,
            };
        }
    }

    public class Task
    {
        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("title")] public string Title { get; set; }

        // [JsonPropertyName("due_date")]
        // [Display("Due date")]
        // public DateTime DueDate { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
    }
}