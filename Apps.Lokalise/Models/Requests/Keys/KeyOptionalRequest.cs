using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class KeyOptionalRequest
{
    [Display("Key ID")] 
    public string? KeyId { get; set; }
}