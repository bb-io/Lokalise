using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class KeyDto
    {
        [JsonPropertyName("key_id")]
        [Display("Key ID")]
        public int KeyId { get; set; }

        [JsonPropertyName("created_at")]
        [Display("Created at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("key_name")] public KeyName KeyName { get; set; }
        [JsonPropertyName("filenames")] public Filenames Filenames { get; set; }

        [Display("Source translation text")] public string? SourceTranslationText => SourceTranslation?.Translation;
        [Display("Source translation language code")] public string? SourceTranslationLanguageCode => SourceTranslation?.LanguageIso;
        
        [Display("Source translation")]
        public TranslationObj? SourceTranslation { get; set; }

        private IEnumerable<TranslationObj>? _translations;
        
        [Display("Target translations")]
        [JsonPropertyName("translations")]
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
}