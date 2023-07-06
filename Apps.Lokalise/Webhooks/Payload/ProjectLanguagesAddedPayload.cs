using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguagesAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguagesAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectLanguagesAddedPayload : BasePayload
    {
        public List<Language> Languages { get; set; }

        public new LanguagesEvent Convert()
        {
            return new LanguagesEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Languages = Languages
            };
        }
    }


}