using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models;

public class LanguagesEvent : BaseEvent
{
    [Display("Languages")]
    public List<Language> Languages {get; set;}
}