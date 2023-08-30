using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;
public class InitialTmLeverage
{
    [JsonProperty("0%+")]
    public int _0 { get; set; }

    [JsonProperty("60%+")]
    public int _60 { get; set; }

    [JsonProperty("75%+")]
    public int _75 { get; set; }

    [JsonProperty("95%+")]
    public int _95 { get; set; }

    [JsonProperty("100%")]
    public int _100 { get; set; }
}
