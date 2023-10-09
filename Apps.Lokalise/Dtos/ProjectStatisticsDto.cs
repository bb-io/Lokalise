using Apps.Lokalise.Models.Responses.Projects;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class ProjectStatisticsDto
    {
        [Display("Total progress")]
        [JsonProperty("progress_total")]
        public int ProgressTotal { get; set; }

        [Display("Total keys number")]
        [JsonProperty("keys_total")]
        public int KeysTotal { get; set; }

        [JsonProperty("team")]
        public int Team { get; set; }

        [Display("Base words number")]
        [JsonProperty("base_words")]
        public int BaseWords { get; set; }

        [Display("Qa issues total number")]
        [JsonProperty("qa_issues_total")]
        public int QaIssuesTotal { get; set; }

        [Display("Qa issues")]
        [JsonProperty("qa_issues")]
        public QaIssues QaIssues { get; set; }

        [Display("Languages")]
        [JsonProperty("languages")]
        public List<Language> Languages { get; set; }
    }

    public class Language
    {
        [Display("Language ID")]
        [JsonProperty("language_id")]
        public int LanguageId { get; set; }

        [Display("Language ISO")]
        [JsonProperty("language_iso")]
        public string LanguageIso { get; set; }

        [JsonProperty("progress")]
        public int Progress { get; set; }

        [Display("Words to do")]
        [JsonProperty("words_to_do")]
        public int WordsToDo { get; set; }
    }

    public class QaIssues
    {
        [Display("Not reviewed number")]
        [JsonProperty("not_reviewed")]
        public int NotReviewed { get; set; }

        [Display("Unverified number")]
        [JsonProperty("unverified")]
        public int Unverified { get; set; }

        [Display("Spelling grammar number")]
        [JsonProperty("spelling_grammar")]
        public int SpellingGrammar { get; set; }

        [Display("Inconsistent placeholders number")]
        [JsonProperty("inconsistent_placeholders")]
        public int InconsistentPlaceholders { get; set; }

        [Display("Inconsistent html number")]
        [JsonProperty("inconsistent_html")]
        public int InconsistentHtml { get; set; }

        [Display("Different number of urls")]
        [JsonProperty("different_number_of_urls")]
        public int DifferentNumberOfUrls { get; set; }

        [Display("Different urls")]
        [JsonProperty("different_urls")]
        public int DifferentUrls { get; set; }

        [Display("Leading whitespace number")]
        [JsonProperty("leading_whitespace")]
        public int LeadingWhitespace { get; set; }

        [Display("Trailing whitespace number")]
        [JsonProperty("trailing_whitespace")]
        public int TrailingWhitespace { get; set; }

        [Display("Different number of email address")]
        [JsonProperty("different_number_of_email_address")]
        public int DifferentNumberOfEmailAddress { get; set; }

        [Display("Different email address")]
        [JsonProperty("different_email_address")]
        public int DifferentEmailAddress { get; set; }

        [Display("Different brackets")]
        [JsonProperty("different_brackets")]
        public int DifferentBrackets { get; set; }

        [Display("Different numbers")]
        [JsonProperty("different_numbers")]
        public int DifferentNumbers { get; set; }

        [Display("Double space")]
        [JsonProperty("double_space")]
        public int DoubleSpace { get; set; }

        [Display("Special placeholder")]
        [JsonProperty("special_placeholder")]
        public int SpecialPlaceholder { get; set; }

        [Display("Unbalanced brackets")]
        [JsonProperty("unbalanced_brackets")]
        public int UnbalancedBrackets { get; set; }
    }
}
