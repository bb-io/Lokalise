using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Errors;

public class Error
{
    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("code")] public int Code { get; set; }
}