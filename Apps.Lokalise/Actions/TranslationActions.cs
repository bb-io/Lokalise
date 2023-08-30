using Apps.Lokalise.Models.Requests.Translations;
using Apps.Lokalise.Models.Responses.Translations;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TranslationActions
{
    #region Fields

    private readonly LokaliseClient _client;

    #endregion

    #region Constructors

    public TranslationActions()
    {
        _client = new();
    }

    #endregion

    #region Actions

    [Action("Update translation", Description = "Update specific translation")]
    public async Task<Translation> UpdateTranslation(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        [ActionParameter] TranslationRequest pathData,
        [ActionParameter] UpdateTranslationRequest bodyParams)
    {
        var endpoint = $"/projects/{pathData.ProjectId}/translations/{pathData.TranslationId}";
        var request = new LokaliseRequest(endpoint, Method.Put,
                authenticationCredentialsProviders)
            .WithJsonBody(bodyParams);

        var response = await _client.ExecuteWithHandling<TranslationResponse>(request);
        return response.Translation;
    }

    #endregion
}