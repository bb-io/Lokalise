using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysAddedPayload : BasePayload>(myJsonResponse);

    public class ProjectKeysAddedPayload : BasePayload
    {
        public List<KeyWithTags> Keys { get; set; }

        public new KeysEvent Convert()
        {
            return new KeysEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Keys = Keys
            };
        }
    }


}