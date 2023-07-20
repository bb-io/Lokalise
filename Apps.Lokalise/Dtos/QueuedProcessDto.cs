using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class QueuedProcessDto
    {
        public ProcessObj Process { get; set; }
    }

    public class ProcessObj
    {
        [JsonPropertyName("process_id")]
        [Display("Process ID")]
        public string ProcessId { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
