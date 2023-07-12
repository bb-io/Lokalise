namespace Apps.Lokalise.Models.Responses.Base;

public class PaginationResponse<T>
{
    public virtual IEnumerable<T> Items { get; set; }
}