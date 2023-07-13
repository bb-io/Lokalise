using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Apps.Lokalise.Webhooks.Models;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload myDeserializedClass = JsonSerializer.Deserialize<ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload>(myJsonResponse);
    public class _1056
    {
        [JsonPropertyName("0")]
        [Display("0")]
        public int _0 { get; set; }

        [JsonPropertyName("50")]
        [Display("50")]
        public int _50 { get; set; }

        [JsonPropertyName("75")]
        [Display("75")]
        public int _75 { get; set; }

        [JsonPropertyName("85")]
        [Display("85")]
        public int _85 { get; set; }

        [JsonPropertyName("95")]
        [Display("95")]
        public int _95 { get; set; }

        [JsonPropertyName("100%")]
        [Display("100%")]
        public int _100 { get; set; }
    }

    public class _600
    {
        [JsonPropertyName("0")]
        [Display("0")]
        public int _0 { get; set; }

        [JsonPropertyName("50")]
        [Display("50")]
        public int _50 { get; set; }

        [JsonPropertyName("75")]
        [Display("75")]
        public int _75 { get; set; }

        [JsonPropertyName("85")]
        [Display("85")]
        public int _85 { get; set; }

        [JsonPropertyName("95")]
        [Display("95")]
        public int _95 { get; set; }

        [JsonPropertyName("100%")]
        [Display("100%")]
        public int _100 { get; set; }
    }

    public class InitialTmLeverage
    {
        [JsonPropertyName("600")]
        [Display("600")]
        public _600 _600 { get; set; }

        [JsonPropertyName("1056")]
        [Display("1056")]
        public _1056 _1056 { get; set; }
    }

    public class ProjectTaskInitialTmLeverageCalculatedPayload : BasePayload
    {
        [JsonPropertyName("task")]
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
                Description = Task.Description,
            };
        }
    }

    public class TaskLeverage
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("initial_tm_leverage")]
        [Display("Initial TM leverage")]
        public InitialTmLeverage InitialTmLeverage { get; set; }
    }


}