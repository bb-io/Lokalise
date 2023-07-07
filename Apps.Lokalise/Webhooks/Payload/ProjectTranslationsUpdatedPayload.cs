using Apps.Lokalise.Webhooks.Models;
using Blackbird.Applications.Sdk.Common;
using System.Linq;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationsUpdatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationsUpdatedPayload : BasePayload>(myJsonResponse);
    public class ProjectTranslationsUpdatedPayload : BasePayload
    {
        public List<TranslationsUpdated> Translations { get; set; }

        public override TranslationsEvent Convert()
        {
            return new TranslationsEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                Translations = Translations.Select(x => new Models.Translation
                {
                    LanguageId = x.Language.Id,
                    Iso = x.Language.Iso,
                    LanguageName = x.Language.Name,
                    KeyId = x.Key.Id,
                    KeyName = x.Key.Name,
                    TranslationId = x.Id,
                    TranslationValue = x.Value,
                    PreviousTranslationValue = x.PreviousValue
                }).ToList(),                
            };
        }
    }

    public class TranslationsUpdated
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string PreviousValue { get; set; }
        public Language Language { get; set; }
        public KeyName Key { get; set; }
    }


}