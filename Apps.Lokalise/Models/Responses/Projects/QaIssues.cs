namespace Apps.Lokalise.Models.Responses.Projects;
public class QaIssues
{
    public int NotReviewed { get; set; }
    public int Unverified { get; set; }
    public int SpellingGrammar { get; set; }
    public int InconsistentPlaceholders { get; set; }
    public int InconsistentHtml { get; set; }
    public int DifferentNumberOfUrls { get; set; }
    public int DifferentUrls { get; set; }
    public int LeadingWhitespace { get; set; }
    public int TrailingWhitespace { get; set; }
    public int DifferentNumberOfEmailAddress { get; set; }
    public int DifferentEmailAddress { get; set; }
    public int DifferentBrackets { get; set; }
    public int DifferentNumbers { get; set; }
    public int DoubleSpace { get; set; }
    public int SpecialPlaceholder { get; set; }
    public int UnbalancedBrackets { get; set; }
}