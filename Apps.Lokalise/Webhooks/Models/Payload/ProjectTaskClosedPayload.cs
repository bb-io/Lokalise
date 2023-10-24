using Apps.Lokalise.Webhooks.Models.EventResponse;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectTaskClosedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskClosedPayload : BasePayload>(myJsonResponse);
public class ProjectTaskClosedPayload : BasePayload
{
    [JsonProperty("task")] public Task Task { get; set; }

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
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    // [JsonProperty("due_date")]
    // [Display("Due date")]
    // public DateTime DueDate { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}