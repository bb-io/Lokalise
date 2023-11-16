using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class TaskLanguageEvent : TaskEvent
{
    [Display("Language ID")]
    public string LanguageId { get; set; }

    [Display("Language ISO code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string LanguageName { get; set; }
}