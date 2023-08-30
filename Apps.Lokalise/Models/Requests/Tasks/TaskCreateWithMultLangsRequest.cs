using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateWithMultLangsRequest : BaseTaskCreateRequest
{
    [Display("Languages")]
    public IEnumerable<TaskLanguage> Languages { get; set; }

    public TaskCreateWithMultLangsRequest()
    {
    }

    public TaskCreateWithMultLangsRequest(TaskCreateRequest input)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
        Keys = input.Keys;
        Languages = new[]
        {
            new TaskLanguage()
            {
                LanguageIso = input.LanguageIso,
                Users = input.Users,
                Groups = input.Groups
            }
        };
        SourceLanguageIso = input.SourceLanguageIso;
        AutoCloseLanguages = input.AutoCloseLanguages;
        AutoCloseTask = input.AutoCloseTask;
        AutoCloseItems = input.AutoCloseItems;
        TaskType = input.TaskType;
        ParentTaskId = input.ParentTaskId;
        ClosingTags = input.ClosingTags;
        DoLockTranslations = input.DoLockTranslations;
        CustomTranslationStatusIds = input.CustomTranslationStatusIds;
    }
}