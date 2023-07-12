using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class LanguageDto
    {
        [JsonPropertyName("lang_id")]
        [Display("Language id")]
        public long LangId { get; set; }

        [JsonPropertyName("lang_iso")]
        [Display("Language iso")]
        public string LangIso { get; set; }
        
        [JsonPropertyName("lang_name")]
        [Display("Language name")]
        public string LangName { get; set; }
        
        [JsonPropertyName("is_rtl")]
        [Display("Is rtl")]
        public bool IsRtl { get; set; }

    }
}
