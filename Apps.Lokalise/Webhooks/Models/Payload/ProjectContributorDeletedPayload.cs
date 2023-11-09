using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectContributorDeletedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectContributorDeletedPayload : BasePayload>(myJsonResponse);
public class ProjectContributorDeletedPayload : BasePayload
{
    [JsonProperty("contributor")]
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