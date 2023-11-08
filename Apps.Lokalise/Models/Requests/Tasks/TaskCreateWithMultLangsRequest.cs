using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateWithMultLangsRequest : BaseTaskCreateRequest
{
    [Display("Languages")] public IEnumerable<TaskLanguage> Languages { get; set; }

    public TaskCreateWithMultLangsRequest()
    {
    }

    public TaskCreateWithMultLangsRequest(TaskCreateRequest input)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
        Keys = input.Keys;
        Languages = input.Languages.Select(x => new TaskLanguage()
        {
            LanguageIso = x,
            Users = input.Users,
            Groups = input.Groups
        });
        SourceLanguageIso = input.SourceLanguageIso;
        AutoCloseLanguages = input.AutoCloseLanguages;
        AutoCloseTask = input.AutoCloseTask;
        AutoCloseItems = input.AutoCloseItems;
        LokaliseTaskType = input.LokaliseTaskType;
        ParentTaskId = input.ParentTaskId;
        ClosingTags = input.ClosingTags;
        DoLockTranslations = input.DoLockTranslations;
        CustomTranslationStatusIds = input.CustomTranslationStatusIds;
    }
}