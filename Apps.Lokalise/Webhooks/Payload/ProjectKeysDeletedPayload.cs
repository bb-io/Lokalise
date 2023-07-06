using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeysDeletedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeysDeletedPayload : BasePayload>(myJsonResponse);

    public class Key
    {
        [Display("Key ID")]
        public int Id { get; set; }

        [Display("Key name")]
        public string Name { get; set; }
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeysDeletedPayload : BasePayload
    {
        public List<Key> Keys { get; set; }

        public new KeysDeletedEvent Convert()
        {
            return new KeysDeletedEvent
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