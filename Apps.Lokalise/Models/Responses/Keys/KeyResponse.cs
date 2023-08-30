using Apps.Lokalise.Dtos;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Keys;

public class KeyResponse
{
    [JsonProperty("key")]
    public KeyDto Key { get; set; }
}