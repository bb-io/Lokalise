using Apps.Lokalise.Dtos;
using RestSharp;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Models.Input;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class KeysDataHandler(InvocationContext invocationContext, [ActionParameter]CommentAddedWebhookInput input)
    : LokaliseInvocable(invocationContext), IAsyncDataSourceHandler
{
    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var keys = new List<KeyDto>();
        
        foreach (var projectId in input.Projects)
        {
            var endpoint = $"/projects/{projectId}/keys";
            var items = await Client.ExecuteWithHandling<KeysWrapper>(new LokaliseRequest(endpoint, Method.Get, Creds));
            keys.AddRange(items.Items);
        }

        return keys
            .Where(x => context.SearchString == null ||
                        x.KeyName.GetNonEmptyName().Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .Take(20)
            .ToDictionary(x => x.KeyId, x => x.KeyName.GetNonEmptyName());
    }
}