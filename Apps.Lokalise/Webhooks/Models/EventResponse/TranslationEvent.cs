using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class TranslationEvent : BaseEvent
{
    private string _keyId;
    
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
    
    public KeyDto Key { get; set; }

    [Display("Key name")]
    public string KeyName { get; set; }

    public TranslationEvent(string keyId)
    {
        _keyId = keyId;
    }
    
    public string GetKeyId()
    {
        return _keyId;
    }
}