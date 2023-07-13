using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Responses.Segments;

public class SegmentResponse
{
    [JsonPropertyName("project_id")]
    [Display("Project id")]
    public string ProjectId { get; set; }

    [JsonPropertyName("key_id")]
    [Display("Key id")]
    public string KeyId { get; set; }

    [JsonPropertyName("language_iso")]
    [Display("Language code")]
    public string LanguageIso { get; set; }

    [JsonPropertyName("segment")]
    public SegmentDto Segment { get; set; }

}