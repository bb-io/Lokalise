using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models
{
    public class TaskEvent : BaseEvent
    {
        [Display("Task ID")]
        public int TaskId { get; set; }

        [Display("Task type")]
        public string Type { get; set; }

        [Display("Task title")]
        public string Title { get; set; }

        //[Display("Task due date")]
        //public DateTime DueDate { get; set; }

        [Display("Task description")]
        public string Description { get; set; }
    }
}
