using System.Text.Json.Serialization;

namespace Apps.Lokalise.Dtos;

public class Filenames
{
    [JsonPropertyName("ios")] public string Ios { get; set; }
    [JsonPropertyName("android")] public string Android { get; set; }
    [JsonPropertyName("web")] public string Web { get; set; }
    [JsonPropertyName("other")] public string Other { get; set; }
}