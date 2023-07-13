using System.Text.Json.Serialization;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectContributorAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectContributorAddedPayload : BasePayload>(myJsonResponse);
    public class Contributor
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }

    public class ProjectContributorAddedPayload : BasePayload
    {
        [JsonPropertyName("contributor")]
        public Contributor Contributor { get; set; }

        public override ContributerEvent Convert()
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