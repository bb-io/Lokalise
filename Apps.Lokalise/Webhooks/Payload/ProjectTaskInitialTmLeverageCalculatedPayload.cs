using System.Text.Json.Serialization;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Lokalise.Webhooks.Payload
{
    // ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload myDeserializedClass = JsonConvert.DeserializeObject<ProjectTaskInitial_tm_leverageCalculatedPayload : BasePayload>(myJsonResponse);
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
        [JsonPropertyName("task")]
        public TaskLeverage Task { get; set; }
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