using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class KeyRequest
{
    [Display("Key ID")] public long KeyId { get; set; }
    [Display("Project ID")] public string ProjectId { get; set; }
}