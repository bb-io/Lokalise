using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class ListAllFilesRequest
    {
        [Display("Project Id")]
        public string ProjectId { get; set; }
        
        [Display("File name filter")]
        
        public string? FilterFileName { get; set; }
    }
}
