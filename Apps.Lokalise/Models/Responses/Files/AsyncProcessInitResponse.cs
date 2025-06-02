using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class AsyncProcessInitResponse
    {
        [JsonProperty("process_id")]
        public string ProcessId { get; set; }
    }

    public class AsyncProcessResponse
    {
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("process")]
        public AsyncProcessDto Process { get; set; }
    }
}
