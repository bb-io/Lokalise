using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Requests.Tasks;

public class TaskUpdateRequest
{
    [JsonProperty("title")] public string? Title { get; set; }

    [JsonProperty("due_date")] public string? DueDate { get; set; }

    [JsonProperty("description")] public string? Description { get; set; }

    [JsonProperty("languages")] public IEnumerable<TaskLanguage>? Languages { get; set; }

    [JsonProperty("auto_close_languages")] public bool? AutoCloseLanguages { get; set; }

    [JsonProperty("auto_close_task")] public bool? AutoCloseTask { get; set; }

    [JsonProperty("auto_close_items")] public bool? AutoCloseItems { get; set; }

    [JsonProperty("close_task")] public bool? CloseTask { get; set; }

    [JsonProperty("closing_tags")] public IEnumerable<string>? ClosingTags { get; set; }

    [JsonProperty("do_lock_translations")] public bool? DoLockTranslations { get; set; }

    public TaskUpdateRequest(TaskUpdateInput input)
    {
        Title = input.Title;
        DueDate = input.DueDate;
        Description = input.Description;
        AutoCloseLanguages = input.AutoCloseLanguages;
        AutoCloseTask = input.AutoCloseTask;
        AutoCloseItems = input.AutoCloseItems;
        CloseTask = input.CloseTask;
        ClosingTags = input.ClosingTags;
        DoLockTranslations = input.DoLockTranslations;
        Languages = input.Languages?.Select(x => new TaskLanguage()
        {
            LanguageIso = x,
            Users = input.Users,
            Groups = input.Groups
        });
    }
}