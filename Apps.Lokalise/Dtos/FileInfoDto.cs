using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class FileInfoDto
{
    [JsonProperty("file_id")]
    [Display("File ID")]
    public long FileId { get; set; }

    [JsonProperty("filename")]
    [Display("File name")]
    public string FileName { get; set; }

    [JsonProperty("key_count")]
    [Display("Key count")]
    public int KeyCount { get; set; }
}