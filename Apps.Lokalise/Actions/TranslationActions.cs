using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Translations;
using Apps.Lokalise.Models.Responses.Keys;
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

    [Action("Update key translation", Description = "Update specific translation using key ID and locale")]
    public async Task<Translation> UpdateKeyTranslation([ActionParameter] KeyTranslationRequest input,
        [ActionParameter] UpdateTranslationRequest bodyParams)
    {
        var endpoint1 = $"/projects/{input.ProjectId}/keys/{input.KeyId}";

        var request1 = new LokaliseRequest(endpoint1, Method.Get, Creds);
        var keydata = await Client.ExecuteWithHandling<KeyResponse>(request1);

        var translationID = keydata.Key.Translations.Where(y => y.LanguageIso == input.LanguageCode).Select(x => x.TranslationId);
        if (translationID is null) 
        {
            throw new Exception($"No translation was found for language code {input.LanguageCode}");
        }

        var endpoint = $"/projects/{input.ProjectId}/translations/{translationID.FirstOrDefault()}";
        var request = new LokaliseRequest(endpoint, Method.Put, Creds)
            .WithJsonBody(bodyParams);

        var response = await Client.ExecuteWithHandling<TranslationResponse>(request);
        return response.Translation;
    }

    #endregion
}