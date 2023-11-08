using Apps.Lokalise.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskUpdateInput
{
    [Display("Title")] public string? Title { get; set; }

    [Display("Due date")] public string? DueDate { get; set; }

    [Display("Description")] public string? Description { get; set; }

    [Display("Languages")] 
    [DataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string>? Languages { get; set; }
    
    public IEnumerable<string>? Users { get; set; }
    
    public IEnumerable<string>? Groups { get; set; }

    [Display("Auto close languages")] public bool? AutoCloseLanguages { get; set; }

    [Display("Auto close task")] public bool? AutoCloseTask { get; set; }

    [Display("Auto close items")] public bool? AutoCloseItems { get; set; }

    [Display("Close task")] public bool? CloseTask { get; set; }

    [Display("Closing tags")] public IEnumerable<string>? ClosingTags { get; set; }

    [Display("Do lock translations")] public bool? DoLockTranslations { get; set; }
}