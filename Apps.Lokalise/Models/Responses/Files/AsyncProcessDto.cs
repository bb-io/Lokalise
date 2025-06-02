using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class AsyncProcessDto
    {
        [JsonProperty("process_id")]
        public string ProcessId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public ProcessDetailsDto Details { get; set; }
    }

    public class ProcessDetailsDto
    {
        [JsonProperty("file_size_kb")]
        public int FileSizeKb { get; set; }

        [JsonProperty("total_number_of_keys")]
        public int TotalNumberOfKeys { get; set; }

        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }
    }
}
