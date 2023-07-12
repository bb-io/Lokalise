using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Segments
{
    public class ListAllSegmentsResponse
    {
        public IEnumerable<SegmentDto> Segments { get; set; }
    }
}
