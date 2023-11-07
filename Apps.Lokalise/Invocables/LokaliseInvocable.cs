using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.Invocables;

public class LokaliseInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected LokaliseClient Client { get; }

    public LokaliseInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}