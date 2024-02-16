using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class Filenames
{
    [JsonProperty("ios")] public string Ios { get; set; }
    [JsonProperty("android")] public string Android { get; set; }
    [JsonProperty("web")] public string Web { get; set; }
    [JsonProperty("other")] public string Other { get; set; }
    
    public string GetNonEmptyName()
    {
        if (!string.IsNullOrEmpty(Ios))
        {
            return Ios;
        }
        if (!string.IsNullOrEmpty(Android))
        {
            return Android;
        }
        if (!string.IsNullOrEmpty(Web))
        {
            return Web;
        }
        if (!string.IsNullOrEmpty(Other))
        {
            return Other;
        }
        
        return string.Empty;
    }
}