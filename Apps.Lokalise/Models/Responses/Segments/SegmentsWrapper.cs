using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;

namespace Apps.Lokalise.Models.Responses.Segments
{
    public class SegmentsWrapper : PaginationResponse<SegmentDto>
    {
        [JsonPropertyName("segments")]
        public override IEnumerable<SegmentDto> Items { get; set; }
    }
}
