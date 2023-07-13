using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Segments
{
    public class ListAllSegmentsPathRequest
    {
        [Display("Project id")] public string ProjectId { get; set; }
        [Display("Key id")] public long KeyId { get; set; }
        [Display("Language code")] public string LanguageCode { get; set; }
    }
}