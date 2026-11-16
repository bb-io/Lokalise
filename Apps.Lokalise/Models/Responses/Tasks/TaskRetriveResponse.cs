using Newtonsoft.Json;

namespace Apps.Lokalise.Models.Responses.Tasks;

public class TaskRetriveResponse
{
    [JsonProperty("task")]
    public TaskResponse Task { get; set; }

    [JsonProperty("skipped_languages")]
    public List<SkippedTaskLanguage> SkippedLanguages { get; set; } = new();

    public TaskResponse GetCreatedTask()
    {
        Task.SkippedLanguages = SkippedLanguages ?? new();
        Task.FillLanguageCodesArray();
        return Task;
    }
}
