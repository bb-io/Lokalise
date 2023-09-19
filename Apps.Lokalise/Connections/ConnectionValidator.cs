using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Lokalise.Connections;

public class ConnectionValidator : IConnectionValidator
{
    private LokaliseClient Client => new();
    
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var request = new LokaliseRequest("/system/languages", Method.Get, authProviders);

        try
        {
            var response = await Client.ExecuteWithHandling(request);
            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }
    }
}