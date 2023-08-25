using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Segments;

public class SegmentResponse
{
    [JsonProperty("project_id")]
    [Display("Project ID")]
    public string ProjectId { get; set; }

    [JsonProperty("key_id")]
    [Display("Key ID")]
    public string KeyId { get; set; }

    [JsonProperty("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonProperty("segment")]
    public SegmentDto Segment { get; set; }

}