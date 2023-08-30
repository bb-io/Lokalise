using Apps.Lokalise.Webhooks.Models;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskCreatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskCreatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTaskCreatedPayload : BasePayload
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
            };
        }
    }

}