using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyAddedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyAddedPayload : BasePayload>(myJsonResponse);
    public class KeyWithTags
    {
        [Display("Key ID")]
        public int Id { get; set; }

        [Display("Key name")]
        public string Name { get; set; }

        [Display("Key base value")]
        public string BaseValue { get; set; }

        [Display("Key tags")]
        public List<string> Tags { get; set; }
    }

    public class ProjectKeyAddedPayload : BasePayload
    {
        public KeyWithTags Key { get; set; }

        public override KeyEvent Convert()
        {
            return new KeyEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id= Key.Id,
                Name = Key.Name,
                BaseValue = Key.BaseValue,
                Tags = Key.Tags,
            };
        }
    }


}