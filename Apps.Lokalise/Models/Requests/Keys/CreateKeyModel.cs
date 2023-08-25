using Apps.Lokalise.Dtos;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Keys;

public class CreateKeyModel
{
    [JsonProperty("key_name")] public string KeyName { get; set; }
    [JsonProperty("platforms")] public List<string> Platforms { get; set; }
    [JsonProperty("description")] public string? Description { get; set; }
    [JsonProperty("filenames")] public Filenames? Filenames { get; set; }
    [JsonProperty("tags")] public IEnumerable<string>? Tags { get; set; }
    [JsonProperty("comments")] public IEnumerable<string>? Comments { get; set; }
    [JsonProperty("screenshots")] public IEnumerable<Screenshot>? Screenshots { get; set; }
    [JsonProperty("is_plural")] public bool? IsPlural { get; set; }
    [JsonProperty("plural_name")] public string? PluralName { get; set; }
    [JsonProperty("is_hidden")] public bool? IsHidden { get; set; }
    [JsonProperty("is_archived")] public bool? IsArchived { get; set; }
    [JsonProperty("context")] public string? Context { get; set; }
    [JsonProperty("char_limit")] public int? CharLimit { get; set; }
    [JsonProperty("custom_attributes")] public string? CustomAttributes { get; set; }

    public CreateKeyModel(CreateKeyInput input)
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