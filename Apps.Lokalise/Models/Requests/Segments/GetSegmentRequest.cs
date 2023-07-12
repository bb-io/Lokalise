namespace Apps.Lokalise.Models.Requests.Segments
{
    public class GetSegmentRequest
    {
        public string ProjectId { get; set; }
        public string KeyId { get; set; }
        public string LanguageCode { get; set; }

        public string SegmentNumber { get; set; }
    }
}
