using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Errors;

public class ErrorResponse
{
    [JsonProperty("error")]
    public Error Error { get; set; }

}