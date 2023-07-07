using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationUpdatedPayload : BasePayload
    {
        public TranslationUpdated Translation { get; set; }
        public KeyName Key { get; set; }
        public Language Language { get; set; }

        public override TranslationEvent Convert()
        {
            return new TranslationEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                LanguageId = Language.Id,
                Iso = Language.Iso,
                LanguageName = Language.Name,
                KeyId= Key.Id,
                KeyName= Key.Name,
                TranslationId= Translation.Id,
                TranslationValue= Translation.Value,
                PreviousTranslationValue = Translation.PreviousValue
            };
        }
    }

    public class TranslationUpdated
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string PreviousValue { get; set; }

        
    }


}