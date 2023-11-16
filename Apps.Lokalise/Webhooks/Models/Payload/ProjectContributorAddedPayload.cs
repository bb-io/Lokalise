using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectContributorAddedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectContributorAddedPayload : BasePayload>(myJsonResponse);
public class Contributor
{
    [JsonProperty("email")]
    public string Email { get; set; }
}

public class ProjectContributorAddedPayload : BasePayload
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
            Email= Contributor.Email
        };
    }
}