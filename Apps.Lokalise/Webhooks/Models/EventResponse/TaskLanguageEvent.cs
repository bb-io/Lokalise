using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models.EventResponse;

public class TaskLanguageEvent : BaseEvent
{
    [Display("Task ID")]
    public string TaskId { get; set; }

    [Display("Task type")]
    public string Type { get; set; }

    [Display("Task title")]
    public string Title { get; set; }

    //[Display("Task due date")]
    //public DateTime DueDate { get; set; }

    [Display("Task description")]
    public string Description { get; set; }

    [Display("Language ID")]
    public string LanguageId { get; set; }

    [Display("Language ISO code")]
    public string Iso { get; set; }

    [Display("Language name")]
    public string LanguageName { get; set; }
}