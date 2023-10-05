using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class RetrieveKeyRequest : KeyRequest
{
    [Display("Disable references")] public bool? DisableReferences { get; set; }
}