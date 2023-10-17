using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Errors;
using Blackbird.Applications.Sdk.Common.Authentication;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Lokalise.RestSharp;

public class LokaliseClient : RestClient
{
    #region Constructors

    public LokaliseClient() : base(new RestClientOptions { BaseUrl = new Uri("https://api.lokalise.com/api2/") })
    {
    }

    #endregion

    #region Execute methods

    public async Task<T> ExecuteWithHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content);
    }

    public async Task<RestResponse> ExecuteWithHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);

        if (response.IsSuccessStatusCode)
            return response;

        if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
        {
            await Task.Delay(1000);
            return await ExecuteWithHandling(request);
        }

        throw ConfigureRequestException(response.Content);
    }

    private Exception ConfigureRequestException(string content)
    {
        var error = JsonConvert.DeserializeObject<ErrorResponse>(content);
        return new($"{error.Error.Message}; Code: {error.Error.Code}");
    }

    #endregion

    public async Task<QueuedProcessDto> PollFileImportOperation(string projectId, string processId,
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
    {
        var request = new LokaliseRequest($"/projects/{projectId}/processes/{processId}",
            Method.Get, authenticationCredentialsProviders);

        var response = await ExecuteWithHandling<QueuedProcessDto>(request);
        while (response?.Process.Status != "finished")
        {
            await Task.Delay(2000);
            response = await ExecuteWithHandling<QueuedProcessDto>(request);
        }

        return response;
    }
}