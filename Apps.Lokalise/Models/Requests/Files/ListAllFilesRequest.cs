using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class ListAllFilesRequest : ProjectRequest
    {
        [Display("File name filter")]
        public string? FilterFileName { get; set; }
    }
}
