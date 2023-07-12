using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Languages;

public class AddLanguageToProjectRequest
{
    [JsonPropertyName("languages")] public AddLanguageData[] Languages { get; set; }

    public AddLanguageToProjectRequest(AddLanguageToProjectInput input)
    {
        Languages = new[] { new AddLanguageData(input) };
    }
}