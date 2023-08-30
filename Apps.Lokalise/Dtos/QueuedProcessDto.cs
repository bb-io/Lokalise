using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos
{
    public class QueuedProcessDto
    {
        public ProcessObj Process { get; set; }
    }

    public class ProcessObj
    {
        [JsonProperty("process_id")]
        [Display("Process ID")]
        public string ProcessId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
