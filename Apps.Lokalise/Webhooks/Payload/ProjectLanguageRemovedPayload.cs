using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectLanguageRemovedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectLanguageRemovedPayload : BasePayload>(myJsonResponse);
    public class Language
    {
        [Display("Language ID")]
        public int Id { get; set; }

        [Display("ISO code")]
        public string Iso { get; set; }

        [Display("Name")]
        public string Name { get; set; }
    }

    public class ProjectLanguageRemovedPayload : BasePayload
    {
        public Language Language { get; set; }

        public override LanguageEvent Convert()
        {
            return new LanguageEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id = Language.Id,
                Iso = Language.Iso,
                Name = Language.Name
            };
        }
    }


}