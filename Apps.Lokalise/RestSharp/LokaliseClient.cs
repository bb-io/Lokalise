using Apps.Lokalise.Constants;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Apps.Lokalise.Models.Responses.Errors;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
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
        return JsonConvert.DeserializeObject<T>(response.Content, JsonConfig.DeserializeSettings);
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
        if (error?.Error?.Message == "Not Found" || error?.Error?.Code == 404)
        {
            return new PluginApplicationException($"Error: {error.Error.Message}; Nothing was found using your inputs, please check and try again");
        }
        if (error?.Error?.Message == "Forbidden" || error?.Error?.Code == 403)
        {
            return new PluginMisconfigurationException(error.Error.Message);
        }

        return new PluginApplicationException($"{error.Error.Message}; Code: {error.Error.Code}");
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

    public async Task<List<TV>> ExecutePaginated<T, TV>(RestRequest request, int limit = 100) where T : PaginationResponse<TV>
    {
        var results = new List<TV>();
        T response;
        var page = 1;

        do
        {
            request.AddParameter("limit", limit);
            request.AddParameter("page", page++);

            response = await ExecuteWithHandling<T>(request);
            results.AddRange(response.Items);
        } while (response.Items.Count() == limit && response.Items.Any());

        return results;
    }
}