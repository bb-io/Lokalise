using Apps.Lokalise.Webhooks.Models.EventResponse;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload.Base;

public class TaskPayload : BasePayload
{
    [JsonProperty("task")]
    public Task Task { get; set; }
    
    public override TaskEvent Convert()
    {
        return new TaskEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            TaskId = Task.Id,
            Title= Task.Title,
            //DueDate= Task.Due_date,
            Description= Task.Description,
            Type = Task.Type,
        };
    }
}

public class Task
{
    [JsonProperty("id")] public string Id { get; set; }

    [JsonProperty("type")] public string Type { get; set; }

    [JsonProperty("title")] public string Title { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
}