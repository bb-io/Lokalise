using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectKeyModifiedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload : BasePayload>(myJsonResponse);

    public class KeyModified
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PreviousName { get; set; }
        public Filenames Filenames { get; set; }
    }

    public class ProjectKeyModifiedPayload : BasePayload
    {
        public KeyModified Key { get; set; }

        public new KeyModifiedEvent Convert()
        {
            return new KeyModifiedEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Id = Key.Id,
                Name = Key.Name,
                PreviousName = Key.PreviousName,
                IOS = Key.Filenames.Ios,
                Android= Key.Filenames.Android,
                Web = Key.Filenames.Web,
                Other= Key.Filenames.Other,
            };
        }
    }


}