using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorAddedPayload : BasePayload>(myJsonResponse);
    public class Contributor
    {
        public string Email { get; set; }
    }

    public class ProjectContributorAddedPayload : BasePayload
    {
        public Contributor Contributor { get; set; }

        public new ContributerEvent Convert()
        {
            return new ContributerEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Email= Contributor.Email
            };
        }
    }


}