using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class Screenshot
{
    [JsonProperty("title")]
    public string Title { get; set; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    [JsonProperty("screenshot_tags")]
    public IEnumerable<string> ScreenshotTags { get; set; }
    
    [JsonProperty("data")]
    public string Data { get; set; }
}