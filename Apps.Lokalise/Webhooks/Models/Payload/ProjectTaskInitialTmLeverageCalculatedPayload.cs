using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Models.Payload;

// ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload>(myJsonResponse);
public class _1056
{
    [JsonProperty("0")]
    [Display("0")]
    public int _0 { get; set; }

    [JsonProperty("50")]
    [Display("50")]
    public int _50 { get; set; }

    [JsonProperty("75")]
    [Display("75")]
    public int _75 { get; set; }

    [JsonProperty("85")]
    [Display("85")]
    public int _85 { get; set; }

    [JsonProperty("95")]
    [Display("95")]
    public int _95 { get; set; }

    [JsonProperty("100%")]
    [Display("100%")]
    public int _100 { get; set; }
}

public class _600
{
    [JsonProperty("0")]
    [Display("0")]
    public int _0 { get; set; }

    [JsonProperty("50")]
    [Display("50")]
    public int _50 { get; set; }

    [JsonProperty("75")]
    [Display("75")]
    public int _75 { get; set; }

    [JsonProperty("85")]
    [Display("85")]
    public int _85 { get; set; }

    [JsonProperty("95")]
    [Display("95")]
    public int _95 { get; set; }

    [JsonProperty("100%")]
    [Display("100%")]
    public int _100 { get; set; }
}

public class InitialTmLeverage
{
    [JsonProperty("600")]
    [Display("600")]
    public _600 _600 { get; set; }

    [JsonProperty("1056")]
    [Display("1056")]
    public _1056 _1056 { get; set; }
}

public class ProjectTaskInitialTmLeverageCalculatedPayload : BasePayload
{
    [JsonProperty("task")]
    public TaskLeverage Task { get; set; }

    public override TaskLeverageEvent Convert()
    {
        return new TaskLeverageEvent
        {
            ProjectId = Project.Id,
            ProjectName = Project.Name,
            UserEmail = User.Email,
            UserName = User.Email,
            TaskId = Task.Id,
            Title = Task.Title,
            Leverage = Task.InitialTmLeverage,
            Description = Task.Description
        };
    }
}

public class TaskLeverage
{
    [JsonProperty("id")]
    public string Id { get; set; }
        
    [JsonProperty("title")]
    public string Title { get; set; }
        
    [JsonProperty("description")]
    public string Description { get; set; }
        
    [JsonProperty("initial_tm_leverage")]
    [Display("Initial TM leverage")]
    public InitialTmLeverage InitialTmLeverage { get; set; }
}