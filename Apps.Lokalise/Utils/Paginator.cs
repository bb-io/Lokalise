using Apps.Lokalise.Models.Responses.Base;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Utils;

public static class Paginator
{
    private static readonly LokaliseClient Client;
    
    static Paginator()
    {
        Client = new();
    }
    
    public static async Task<List<TV>> GetAll<T, TV>(AuthenticationCredentialsProvider[] creds, string baseUrl) where T : PaginationResponse<TV>
    {
        var results = new List<TV>();
        T response;
        var page = 1;
        
        do
        {
            var requestUrl = baseUrl.Contains("?") ?
                $"{baseUrl}&page={page++}" :
                $"{baseUrl}?page={page++}";
            
            var request = new LokaliseRequest(requestUrl, Method.Get, creds);
            
            response = await Client.ExecuteWithHandling<T>(request);
            results.AddRange(response.Items);
        } while (response.Items.Any());

        return results;
    }
}