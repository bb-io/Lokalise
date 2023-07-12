using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class KeyDto
    {
        [JsonPropertyName("key_id")]
        [Display("Key id")]
        public int KeyId { get; set; }

        [JsonPropertyName("created_at")]
        [Display("Created at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("description")] public string Description { get; set; }
        [JsonPropertyName("key_name")] public KeyName KeyName { get; set; }
        [JsonPropertyName("filenames")] public Filenames Filenames { get; set; }
        [JsonPropertyName("translations")] public IEnumerable<TranslationObj> Translations { get; set; }
    }
}