using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Glossary
{
    public class GlossaryTermsResponse
    {
        [JsonProperty("data")]
        public List<GlossaryTermDto> Data { get; set; }

        [JsonProperty("meta")]
        public PaginationMeta Meta { get; set; }
    }

    public class GlossaryTermDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty("translations")]
        public List<TranslationDto> Translations { get; set; }
    }

    public class TranslationDto
    {
        [JsonProperty("langId")]
        public int LangId { get; set; }

        [JsonProperty("langIso")]
        public string LangIso { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class PaginationMeta
    {
        [JsonProperty("hasMore")]
        public bool HasMore { get; set; }

        [JsonProperty("nextCursor")]
        public int NextCursor { get; set; }
    }

}
