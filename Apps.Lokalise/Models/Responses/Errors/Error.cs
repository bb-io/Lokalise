using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Errors;

public class Error
{
    [JsonProperty("message")] public string Message { get; set; }
    [JsonProperty("code")] public int Code { get; set; }
}