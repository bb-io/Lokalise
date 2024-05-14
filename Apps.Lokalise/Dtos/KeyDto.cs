using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class KeyDto
{
    [JsonProperty("key_id")]
    [Display("Key ID")]
    public string KeyId { get; set; }

    [JsonProperty("created_at")]
    [Display("Created at")]
    public string CreatedAt { get; set; }

    [JsonProperty("description")] public string Description { get; set; }
    [JsonProperty("tags")] public IEnumerable<string> Tags { get; set; }
    [JsonProperty("key_name"), Display("Key name")] public KeyName KeyName { get; set; }
    [JsonProperty("filenames"), Display("Filenames")] public Filenames Filenames { get; set; }
    [Display("Base language")] public TranslationObj? SourceTranslation { get; set; }

    [Display("Translations")]
    [JsonProperty("translations")]
    public IEnumerable<TranslationObj>? Translations { get; set; }
    
}