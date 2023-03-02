using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.Providers;
public class HttpRequestProvider
{
    public RestResponse Get(
        string url,
        Dictionary<string, string> queryParameters,
        AuthenticationCredentialsProvider authenticationCredentialsProvider
        )
    {
        var client = new RestClient(url);
        var request = new RestRequest();
        HandleAuthentication(request, authenticationCredentialsProvider);
        AddParameters(request, queryParameters);
        return client.Get(request);
    }

    public RestResponse Post(
        string url,
        Dictionary<string, string> queryParameters,
        Dictionary<string, string> headers,
        object body,
        AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var client = new RestClient(url);
        var request = new RestRequest();
        HandleAuthentication(request, authenticationCredentialsProvider);
        AddParameters(request, queryParameters);
        AddHeaders(request, headers);
        if (body is not null)
            request.AddBody(body, "application/json");
        return client.Post(request);
    }

    public RestResponse Put(
        string url,
        Dictionary<string, string> queryParameters,
        Dictionary<string, string> headers,
        object body,
        AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var client = new RestClient(url);
        var request = new RestRequest();
        HandleAuthentication(request, authenticationCredentialsProvider);
        AddParameters(request, queryParameters);
        AddHeaders(request, headers);
        if (body is not null)
            request.AddBody(body, "application/json");
        return client.Put(request);
    }

    public RestResponse Delete(string url,
        Dictionary<string, string> headers,
        AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        var client = new RestClient(url);
        var request = new RestRequest();
        HandleAuthentication(request, authenticationCredentialsProvider);
        AddHeaders(request, headers);
        return client.Delete(request);
    }


    private void AddParameters(RestRequest request, Dictionary<string, string> queryParameters)
    {
        if (queryParameters == null || !queryParameters.Any())
        {
            return;
        }
        foreach (var queryParameter in queryParameters.Where(x => x.Value is not null))
        {
            request.AddParameter(queryParameter.Key, queryParameter.Value);
        }
    }

    private void AddHeaders(RestRequest request, Dictionary<string, string> headers)
    {
        if (headers == null || !headers.Any())
        {
            return;
        }
        foreach (var header in headers)
        {
            request.AddHeader(header.Key, header.Value);
        }
    }

    private void HandleAuthentication(RestRequest request, AuthenticationCredentialsProvider authenticationCredentialsProvider)
    {
        switch (authenticationCredentialsProvider.CredentialsRequestLocation)
        {
            case AuthenticationCredentialsRequestLocation.None:
                return;
            case AuthenticationCredentialsRequestLocation.QueryString:
                request.AddQueryParameter(authenticationCredentialsProvider.KeyName, authenticationCredentialsProvider.Value);
                break;
            case AuthenticationCredentialsRequestLocation.Header:
                request.AddHeader(authenticationCredentialsProvider.KeyName, authenticationCredentialsProvider.Value);
                break;
        }
    }
}
