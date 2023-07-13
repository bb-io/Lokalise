using Apps.Lokalise.RestSharp;
using RestSharp;

namespace Apps.Lokalise.Extensions;

public static class LokaliseRequestExtensions
{
    public static RestRequest WithJsonBody(this LokaliseRequest request, object body)
        => request.AddJsonBody(body);
}