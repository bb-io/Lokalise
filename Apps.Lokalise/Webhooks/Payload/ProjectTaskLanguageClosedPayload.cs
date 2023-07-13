using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskLanguageClosedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskLanguageClosedPayload : BasePayload>(myJsonResponse);

    public class ProjectTaskLanguageClosedPayload : BasePayload
    {
        [JsonPropertyName("task")]
        public Task Task { get; set; }
        
        [JsonPropertyName("language")]
        public Language Language { get; set; }

        public override TaskLanguageEvent Convert()
        {
            return new TaskLanguageEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                TaskId = Task.Id,
                Title = Task.Title,
                //DueDate = Task.Due_date,
                Description = Task.Description,
                LanguageId= Language.Id,
                Iso = Language.Iso,
                LanguageName = Language.Name,
            };
        }
    }

}