using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Keys;

public class CreateKeyRequest
{
    [JsonProperty("keys")]
    public CreateKeyModel[] Keys { get; set; }

    [JsonProperty("use_automations")]
    public bool? UseAutomations { get; set; }
    
    public CreateKeyRequest(CreateKeyInput input)
    {
        Keys = new[] { new CreateKeyModel(input) };
        UseAutomations = input.UseAutomations;
    }
}