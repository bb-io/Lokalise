using Apps.Lokalise.Webhooks.Models.Payload;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class LanguagesEvent : BaseEvent
{
    [Display("Languages")]
    public List<Language> Languages {get; set;}
}