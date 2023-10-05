using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class CreateKeyInput
{
    [Display("Key name")] public string KeyName { get; set; }
    public List<string> Platforms { get; set; }
    public string? Description { get; set; }
    public Filenames? Filenames { get; set; }
    public IEnumerable<string>? Tags { get; set; }
    public IEnumerable<string>? Comments { get; set; }
    public IEnumerable<Screenshot>? Screenshots { get; set; }
    [Display("Is plural")] public bool? IsPlural { get; set; }
    [Display("Plural name")] public string? PluralName { get; set; }
    [Display("Is hidden")] public bool? IsHidden { get; set; }
    [Display("Is archived")] public bool? IsArchived { get; set; }
    public string? Context { get; set; }
    [Display("Char limit")] public int? CharLimit { get; set; }
    [Display("Custom attributes")] public string? CustomAttributes { get; set; }
    [Display("Use automations")] public bool? UseAutomations { get; set; }
}