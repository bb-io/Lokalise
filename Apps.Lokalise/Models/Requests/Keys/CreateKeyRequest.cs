using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Keys;

public class CreateKeyRequest
{
    [JsonPropertyName("keys")]
    public CreateKeyModel[] Keys { get; set; }

    [JsonPropertyName("use_automations")]
    public bool? UseAutomations { get; set; }
    
    public CreateKeyRequest(CreateKeyInput input)
    {
        Keys = new[] { new CreateKeyModel(input) };
        UseAutomations = input.UseAutomations;
    }
}