using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Dtos
{
    public class FileInfoDto
    {
        [JsonPropertyName("file_id")]
        [Display("File id")]
        public long FileId { get; set; }

        [JsonPropertyName("filename")]
        [Display("File name")]
        public string FileName { get; set; }

        [JsonPropertyName("key_count")]
        [Display("Key count")]
        public int KeyCount { get; set; }
    }
}
