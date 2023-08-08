using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Projects
{
    public class DeleteFileRequest : ProjectRequest
    {
        [Display("File ID")]
        public string FileId { get; set; }
    }
}
