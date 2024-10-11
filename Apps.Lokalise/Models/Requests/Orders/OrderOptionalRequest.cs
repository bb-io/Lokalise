using Blackbird.Applications.Sdk.Common;

namespace Apps.Lokalise.Models.Requests.Orders;

public class OrderOptionalRequest
{
    [Display("Order ID")]
    public string? OrderId { get; set; }
}