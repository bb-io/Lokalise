using Apps.Lokalise.DataSourceHandlers.EnumHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks.Base;

public class BaseTaskCreateRequest
{
    [Display("Title")] public string Title { get; set; }
    
    [Display("Task type")]
    [DataSource(typeof(TaskTypeDataHandler))]
    public string TaskType { get; set; }
    
    [Display("Description")] public string? Description { get; set; }

    [Display("Due Date")] public string? DueDate { get; set; }

    [Display("Keys")] public IEnumerable<string>? Keys { get; set; }

    [Display("Source language code")] public string? SourceLanguageIso { get; set; }

    [Display("Auto close languages")] public bool? AutoCloseLanguages { get; set; }

    [Display("Auto close task")] public bool? AutoCloseTask { get; set; }

    [Display("Auto close items")] public bool? AutoCloseItems { get; set; }

    [Display("Parent task ID")] public string? ParentTaskId { get; set; }

    [Display("Closing tags")] public IEnumerable<string>? ClosingTags { get; set; }

    [Display("Do lock translations")] public bool? DoLockTranslations { get; set; }

    [Display("Custom translation status IDs")]
    public IEnumerable<string>? CustomTranslationStatusIds { get; set; }
}