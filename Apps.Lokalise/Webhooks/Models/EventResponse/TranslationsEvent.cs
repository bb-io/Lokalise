using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class Translation
{
    [Display("Translation ID")]
    public string TranslationId { get; set; }

    [Display("Translation")]
    public string TranslationValue { get; set; }

    [Display("Previous translation")]
    public string PreviousTranslationValue { get; set; }

    [Display("Language ID")]
    public string LanguageId { get; set; }

    [Display("Language ISO code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string LanguageName { get; set; }

    [Display("Key ID")]
    public string KeyId { get; set; }

    [Display("Key name")]
    public string KeyName { get; set; }
}

public class TranslationsEvent : BaseEvent
{
    [Display("Translations")]
    public List<Translation> Translations { get; set; }
}