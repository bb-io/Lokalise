using System.Text.Json.Serialization;

namespace Apps.Lokalise.Dtos;

public class Screenshot
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("screenshot_tags")]
    public IEnumerable<string> ScreenshotTags { get; set; }
    
    [JsonPropertyName("data")]
    public string Data { get; set; }
}