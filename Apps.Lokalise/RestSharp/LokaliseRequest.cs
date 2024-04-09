using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Lokalise.RestSharp;

public class LokaliseRequest : RestRequest
{
    public LokaliseRequest(string endpoint, Method method, IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders) : base(endpoint, method)
    {
        var apiToken = authenticationCredentialsProviders.First(p => p.KeyName == "apiToken").Value;
        this.AddHeader("X-Api-Token", apiToken);
    }
}