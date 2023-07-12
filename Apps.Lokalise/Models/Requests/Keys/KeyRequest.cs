using System.Text.Json.Serialization;
using Apps.Lokalise.Dtos;

namespace Apps.Lokalise.Models.Requests.Keys;

public class KeyRequest
{
    [JsonPropertyName("key_name")] public string KeyName { get; set; }
    [JsonPropertyName("platforms")] public List<string> Platforms { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("filenames")] public Filenames? Filenames { get; set; }
    [JsonPropertyName("tags")] public IEnumerable<string>? Tags { get; set; }
    [JsonPropertyName("comments")] public IEnumerable<string>? Comments { get; set; }
    [JsonPropertyName("screenshots")] public IEnumerable<Screenshot>? Screenshots { get; set; }
    [JsonPropertyName("is_plural")] public bool? IsPlural { get; set; }
    [JsonPropertyName("plural_name")] public string? PluralName { get; set; }
    [JsonPropertyName("is_hidden")] public bool? IsHidden { get; set; }
    [JsonPropertyName("is_archived")] public bool? IsArchived { get; set; }
    [JsonPropertyName("context")] public string? Context { get; set; }
    [JsonPropertyName("char_limit")] public int? CharLimit { get; set; }
    [JsonPropertyName("custom_attributes")] public string? CustomAttributes { get; set; }

    public KeyRequest(CreateKeyInput input)
    {
        KeyName = input.KeyName;
        Platforms = input.Platforms;
        Description = input.Description;
        Filenames = input.Filenames;
        Tags = input.Tags;
        Comments = input.Comments;
        Screenshots = input.Screenshots;
        IsPlural = input.IsPlural;
        PluralName = input.PluralName;
        IsHidden = input.IsHidden;
        IsArchived = input.IsArchived;
        Context = input.Context;
        CharLimit = input.CharLimit;
        CustomAttributes = input.CustomAttributes;
    }
}