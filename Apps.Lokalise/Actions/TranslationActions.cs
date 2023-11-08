using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Translations;
using Apps.Lokalise.Models.Responses.Translations;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TranslationActions : LokaliseInvocable
{
    public TranslationActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("Update translation", Description = "Update specific translation")]
    public async Task<Translation> UpdateTranslation([ActionParameter] TranslationRequest pathData,
        [ActionParameter] UpdateTranslationRequest bodyParams)
    {
        var endpoint = $"/projects/{pathData.ProjectId}/translations/{pathData.TranslationId}";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(bodyParams);

        var response = await Client.ExecuteWithHandling<TranslationResponse>(request);
        return response.Translation;
    }

    #endregion
}