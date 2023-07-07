using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectContributorDeletedPayload : BasePayload>(myJsonResponse);
    public class ProjectContributorDeletedPayload : BasePayload
    {
        public Contributor Contributor { get; set; }

        public override ContributerEvent Convert()
        {
            return new ContributerEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Email = Contributor.Email
            };
        }
    }


}