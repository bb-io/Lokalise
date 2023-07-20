using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Errors;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public Error Error { get; set; }

}