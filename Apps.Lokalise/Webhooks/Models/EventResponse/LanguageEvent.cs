using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class LanguageEvent : BaseEvent
{
    [Display("Language ID")]
    public string Id { get; set; }

    [Display("Language ISO code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string Name { get; set; }
}