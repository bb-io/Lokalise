using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Segments;

public class SegmentsWrapper : PaginationResponse<SegmentDto>
{
    [JsonProperty("segments")]
    public override IEnumerable<SegmentDto> Items { get; set; }
}