using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Responses.Keys;

public class KeyResponse
{
    [JsonPropertyName("key")]
    public KeyDto Key { get; set; }
}