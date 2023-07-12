using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Requests.Keys;

public class CreateKeyRequest
{
    [JsonPropertyName("keys")]
    public KeyRequest[] Keys { get; set; }

    [JsonPropertyName("use_automations")]
    public bool? UseAutomations { get; set; }
    
    public CreateKeyRequest(CreateKeyInput input)
    {
        Keys = new[] { new KeyRequest(input) };
        UseAutomations = input.UseAutomations;
    }
}