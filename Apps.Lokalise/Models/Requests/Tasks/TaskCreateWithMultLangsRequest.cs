using System.Web;
using Apps.Lokalise.Models.Requests.Tasks.Base;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Exceptions;
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
        TranslationEngine = input.TranslationEngine;
        SaveAiTranslationToTm = input.SaveAiTranslationToTm;
        ApplyAiTm100Matches = input.ApplyAiTm100Matches;
        MarkVerified = input.MarkVerified;
        TranslateAllSegments = input.TranslateAllSegments;
        IncludeAiScore = input.IncludeAiScore;
    }

    public TaskCreateWithMultLangsRequest(LanguageTaskCreateRequest input, TaskAssigneesRequest assigneesRequest, IEnumerable<string> keys)
    {
        Title = input.Title;
        Description = input.Description;
        DueDate = input.DueDate;
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
        TranslationEngine = input.TranslationEngine;
        SaveAiTranslationToTm = input.SaveAiTranslationToTm;
        ApplyAiTm100Matches = input.ApplyAiTm100Matches;
        MarkVerified = input.MarkVerified;
        TranslateAllSegments = input.TranslateAllSegments;
        IncludeAiScore = input.IncludeAiScore;

        if (ParentTaskId == null) Keys = keys;
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
        TranslationEngine = input.TranslationEngine;
        SaveAiTranslationToTm = input.SaveAiTranslationToTm;
        ApplyAiTm100Matches = input.ApplyAiTm100Matches;
        MarkVerified = input.MarkVerified;
        TranslateAllSegments = input.TranslateAllSegments;
        IncludeAiScore = input.IncludeAiScore;
    }

    public void Validate(bool requireAssignees = false)
    {
        var languages = Languages.ToList();
        var isAiTask = LokaliseTaskType is "automatic_translation" or "lqa_by_ai";

        if (isAiTask)
        {
            if (AutoCloseLanguages == false || AutoCloseTask == false)
                throw new PluginMisconfigurationException(
                    "Auto close languages and Auto close task must be true or omitted for Automatic translation and LQA by AI tasks.");

            if (LokaliseTaskType == "automatic_translation" && AutoCloseItems == false)
                throw new PluginMisconfigurationException(
                    "Auto close items must be true or omitted for Automatic translation tasks.");

            // Lokalise rejects this property for LQA, even when true. Accept either input
            // value and omit it for this task type.
            if (LokaliseTaskType == "lqa_by_ai") AutoCloseItems = null;

            if (languages.Any(x => x.Users?.Any() == true || x.Groups?.Any() == true))
                throw new PluginMisconfigurationException(
                    "Users and Groups must be omitted for Automatic translation and LQA by AI tasks.");

            foreach (var language in languages)
            {
                language.Users = null;
                language.Groups = null;
            }
        }
        else if (requireAssignees && !languages.Any(x => x.Users is not null || x.Groups is not null))
        {
            throw new PluginMisconfigurationException("One of the inputs must be specified: Users or Groups");
        }

        if (LokaliseTaskType != "automatic_translation" &&
            (TranslationEngine is not null || SaveAiTranslationToTm.HasValue || ApplyAiTm100Matches.HasValue ||
             MarkVerified.HasValue || TranslateAllSegments.HasValue || IncludeAiScore.HasValue))
            throw new PluginMisconfigurationException(
                "Translation engine, Save AI translation to TM, Apply AI TM 100% matches, Mark verified, Translate all segments, and Include AI score can only be supplied for Automatic translation tasks.");

        if (TranslationEngine is not null and not ("ai" or "deepl" or "google"))
            throw new PluginMisconfigurationException("Translation engine must be AI (ai), DeepL (deepl), or Google (google).");

        if (IncludeAiScore == true && TranslationEngine is ("deepl" or "google"))
            throw new PluginMisconfigurationException("Include AI score cannot be used with the DeepL or Google translation engine.");

        Languages = languages;
    }
}
