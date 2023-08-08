using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Keys;

public class KeyRequest : ProjectRequest
{
    [Display("Key ID")] 
    public string KeyId { get; set; }
}