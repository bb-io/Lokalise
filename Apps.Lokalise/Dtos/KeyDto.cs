using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class KeyDto
{
    [JsonProperty("key_id")]
    [Display("Key ID")]
    public int KeyId { get; set; }

    [JsonProperty("created_at")]
    [Display("Created at")]
    public string CreatedAt { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("tags")] public IEnumerable<string> Tags { get; set; }
    [JsonProperty("key_name")] public KeyName KeyName { get; set; }
    [JsonProperty("filenames")] public Filenames Filenames { get; set; }

    [Display("Source translation text")] public string? SourceTranslationText => SourceTranslation?.Translation;
    [Display("Source translation language code")] public string? SourceTranslationLanguageCode => SourceTranslation?.LanguageIso;
        
    [Display("Source translation")]
    public TranslationObj? SourceTranslation { get; set; }

    private IEnumerable<TranslationObj>? _translations;
        
    [Display("Target translations")]
    [JsonProperty("translations")]
    public IEnumerable<TranslationObj>? Translations
    {
        get => _translations;
        set
        {
            SourceTranslation = value?.FirstOrDefault();
            _translations = value?.Skip(1);
        }
    }
}