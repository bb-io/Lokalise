using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Files
{
    public class DownloadTaskXLIFFFileRequest : DownloadAllXLIFFFilesRequest
    {
        [JsonProperty("filter_task_id")]
        [Display("Filter task ID")]
        public string FilterTaskId { get; set; }
    }
}
