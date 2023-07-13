using System.Text.Json.Serialization;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class InitialTmLeverage
{
    [JsonPropertyName("0%+")]
    public int _0 { get; set; }

    [JsonPropertyName("60%+")]
    public int _60 { get; set; }

    [JsonPropertyName("75%+")]
    public int _75 { get; set; }

    [JsonPropertyName("95%+")]
    public int _95 { get; set; }

    [JsonPropertyName("100%")]
    public int _100 { get; set; }
}
