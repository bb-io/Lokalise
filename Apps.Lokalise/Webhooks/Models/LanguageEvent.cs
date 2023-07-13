using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Webhooks.Models
{
    public class LanguageEvent : BaseEvent
    {
        [Display("Language ID")]
        public int Id { get; set; }

        [Display("Language ISO code")]
        public string Iso { get; set; }

        [Display("Language name")]
        public string Name { get; set; }
    }
}
