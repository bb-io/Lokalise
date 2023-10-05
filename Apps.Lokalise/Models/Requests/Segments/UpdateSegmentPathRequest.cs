using Apps.Lokalise.DataSourceHandlers;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Segments;

public class UpdateSegmentPathRequest : ProjectRequest
{
    [Display("Key ID")] public long KeyId { get; set; }
        
    [Display("Language code")] 
    [DataSource(typeof(LanguageDataHandler))]
    public string LanguageCode { get; set; }
        
    [Display("Segment number")] public int SegmentNumber { get; set; }
}