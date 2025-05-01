namespace Apps.Lokalise.Models.Responses.Glossary
{
    public class ImportGlossaryResponse
    {
        [Newtonsoft.Json.JsonProperty("data")]
        public List<GlossaryTermDto> Data { get; set; }

        [Newtonsoft.Json.JsonProperty("meta")]
        public PaginationMeta Meta { get; set; }

        [Newtonsoft.Json.JsonProperty("errors")]
        public List<string> Errors { get; set; }
    }
}
