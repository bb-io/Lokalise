using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Segments
{
    public class SegmentsWrapper
    {
        public IEnumerable<SegmentDto> Segments { get; set; }
    }
}
