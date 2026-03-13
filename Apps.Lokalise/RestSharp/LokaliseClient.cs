using Apps.Lokalise.Constants;
using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Apps.Lokalise.Models.Responses.Errors;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Glossaries.Utils.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net;

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

        throw ConfigureRequestException(response);
    }

    private Exception ConfigureRequestException(RestResponse response)
    {
        var content = response.Content;

        if (string.IsNullOrWhiteSpace(content))
            return new PluginApplicationException(
                $"Request failed with status code {(int)response.StatusCode} ({response.StatusCode}).");

        try
        {
            var json = JObject.Parse(content);

            var errorToken = json["error"];
            string? message = null;
            int? code = null;

            if (errorToken?.Type == JTokenType.Object)
            {
                message = errorToken["message"]?.ToString();
                code = errorToken["code"]?.Value<int?>();
            }
            else if (errorToken?.Type == JTokenType.String)
            {
                message = errorToken.ToString();
            }

            message ??= json["message"]?.ToString();
            code ??= json["code"]?.Value<int?>();

            if (string.IsNullOrWhiteSpace(message))
                message = content;

            if (response.StatusCode == HttpStatusCode.NotFound || code == 404 || message == "Not Found")
            {
                return new PluginApplicationException(
                    $"Error: {message}; Nothing was found using your inputs, please check and try again");
            }

            if (response.StatusCode == HttpStatusCode.Forbidden || code == 403 || message == "Forbidden")
            {
                return new PluginApplicationException(
                    "Forbidden. You do not have access to this resource or the API token does not have sufficient permissions.");
            }

            return code.HasValue
                ? new PluginApplicationException($"{message}; Code: {code}")
                : new PluginApplicationException(message);
        }
        catch
        {
            return new PluginApplicationException(
                $"Request failed with status code {(int)response.StatusCode} ({response.StatusCode}). Response: {content}");
        }
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