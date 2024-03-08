using System.Web;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskCreateWithMultLangsRequest : BaseTaskCreateRequest
{
    [Display("Languages")] public IEnumerable<TaskLanguage> Languages { get; set; }

    public TaskCreateWithMultLangsRequest()
    {
    }

    public TaskCreateWithMultLangsRequest(TaskCreateRequest input, TaskAssigneesRequest assigneesRequest)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
        Keys = input.Keys;
        Languages = input.Languages.Select(x => new TaskLanguage()
        {
            LanguageIso = x,
            Users = assigneesRequest.Users,
            Groups = assigneesRequest.Groups
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

    public TaskCreateWithMultLangsRequest(LanguageTaskCreateRequest input, TaskAssigneesRequest assigneesRequest, IEnumerable<string> keys)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
        Keys = keys;
        Languages = new List<TaskLanguage> { new TaskLanguage()
        {
            LanguageIso = input.TargetLanguageIso,
            Users = assigneesRequest.Users,
            Groups = assigneesRequest.Groups
        } };
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

    public TaskCreateWithMultLangsRequest(TaskFromBuiltLangsRequest input)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
        Keys = input.Keys;
        Languages = input.Languages.Select(x =>
            JsonConvert.DeserializeObject<TaskLanguage>(HttpUtility.HtmlDecode(x))!);
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