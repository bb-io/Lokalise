using Apps.Lokalise.Dtos;
using Apps.Lokalise.Extensions;
using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Translations;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Segments;
using Apps.Lokalise.Models.Responses.Translations;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Extensions.System;
using RestSharp;

namespace Apps.Lokalise.Actions;

[ActionList]
public class TranslationActions : LokaliseInvocable
{
    public TranslationActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    #region Actions

    [Action("List translations", Description = "Retrieves a list of project translations")]
    public async Task<ListTranslationResponse> ListTranslations([ActionParameter] ListTranslationRequest input,
        [ActionParameter] ListTranslationQueryRequest queryInput)
    {
        var endpoint = $"/projects/{input.ProjectId}/translations/";
        var query = queryInput.AsLokaliseDictionary().AllIsNotNull();

        var url = endpoint.WithQuery(query);

        var translations = await Paginator.GetAll<TranslationsWrapper, TranslationObj>(Creds, url);

        return new()
        {
            Translations = translations
        };
    }

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