using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskLanguageClosedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskLanguageClosedPayload : BasePayload>(myJsonResponse);

    public class ProjectTaskLanguageClosedPayload : BasePayload
    {
        public Task Task { get; set; }
        public Language Language { get; set; }

        public new TaskLanguageEvent Convert()
        {
            return new TaskLanguageEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                TaskId = Task.Id,
                Title = Task.Title,
                DueDate = Task.Due_date,
                Description = Task.Description,
                LanguageId= Language.Id,
                Iso = Language.Iso,
                LanguageName = Language.Name,
            };
        }
    }

}