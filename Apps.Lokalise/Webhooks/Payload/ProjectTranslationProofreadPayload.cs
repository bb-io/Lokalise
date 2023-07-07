using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTranslationProofreadPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTranslationProofreadPayload : BasePayload>(myJsonResponse);
    public class KeyName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProjectTranslationProofreadPayload : BasePayload
    {
        public Translation Translation { get; set; }
        public KeyName Key { get; set; }
        public Language Language { get; set; }

        public override ProofreadEvent Convert()
        {
            return new ProofreadEvent
            {
                ProjectId = Project.Id,
                ProjectName = Project.Name,
                UserEmail = User.Email,
                UserName = User.Email,
                LanguageId = Language.Id,
                Iso = Language.Iso,
                LanguageName = Language.Name,
                KeyId = Key.Id,
                KeyName = Key.Name,
                TranslationId = Translation.Id,
                TranslationValue = Translation.Value,
                IsProofread = Translation.IsProofread
            };
        }
    }

    public class Translation
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsProofread { get; set; }
    }


}