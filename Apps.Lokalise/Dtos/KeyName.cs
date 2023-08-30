using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class KeyName
{
    [JsonProperty("ios")] public string Ios { get; set; }
    [JsonProperty("android")] public string Android { get; set; }
    [JsonProperty("web")] public string Web { get; set; }
    [JsonProperty("other")] public string Other { get; set; }
}