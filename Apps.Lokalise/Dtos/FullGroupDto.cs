using Newtonsoft.Json;

namespace Apps.Lokalise.Dtos;

public class FullGroupDto
{
    [JsonProperty("group_id")]
    public string GroupId { get; set; }

    public string Name { get; set; }

    public List<string> Members { get; set; }
}