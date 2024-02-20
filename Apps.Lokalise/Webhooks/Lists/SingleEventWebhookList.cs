using System.Net;
using Apps.Lokalise.Models.Responses.Keys;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.RestSharp;
using Apps.Lokalise.Webhooks.Handlers.SingleEventHandlers.Impl;
using Apps.Lokalise.Webhooks.Lists.Base;
using Apps.Lokalise.Webhooks.Models.EventResponse;
using Apps.Lokalise.Webhooks.Models.Input;
using Apps.Lokalise.Webhooks.Models.Payload;
using Apps.Lokalise.Webhooks.Models.Payload.Base;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks.Lists;

[WebhookList]
public class SingleEventWebhookList : WebhookList
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected LokaliseClient Client { get; }

    public SingleEventWebhookList(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    private WebhookResponse<T1> HandlePreflightAndMap<T1, T2>(WebhookRequest webhookRequest, WebhookInput input)
        where T2 : BasePayload where T1 : BaseEvent
    {
        var preflightResponse = new WebhookResponse<T1>()
        {
            HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
            Result = null,
            ReceivedWebhookRequestType = WebhookRequestType.Preflight
        };

        if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            return preflightResponse;

        var data = JsonConvert.DeserializeObject<T2>(webhookRequest.Body.ToString()!);

        if (data is null)
            throw new InvalidCastException(nameof(webhookRequest.Body));

        if (!input.Projects.Contains(data.Project.Id))
            return preflightResponse;

        if (input.UserEmail != null && data.User.Email != input.UserEmail)
            return preflightResponse;

        return new()
        {
            HttpResponseMessage = null,
            Result = (T1)data.Convert()
        };
    }

    private async Task<WebhookResponse<GetKeyEvent>> MapToEventResponse<T>(WebhookResponse<T> response)
        where T : KeyEvent
    {
        if (response.ReceivedWebhookRequestType == WebhookRequestType.Preflight)
        {
            return new WebhookResponse<GetKeyEvent>()
            {
                HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                Result = null,
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        var keyResponse = await GetKeyAsync(response.Result.ProjectId, response.Result.Key.Id);
        return new()
        {
            HttpResponseMessage = null,
            Result = new(response.Result.ProjectId, keyResponse)
        };
    }

    private async Task<KeyResponse> GetKeyAsync(string projectId, string keyId)
    {
        var endpoint = $"/projects/{projectId}/keys/{keyId}";
        var request = new LokaliseRequest(endpoint, Method.Get, Creds);

        var response = await Client.ExecuteWithHandling<KeyResponse>(request);
        return response;
    }

    [Webhook("On project imported", typeof(ProjectImportedHandler),
        Description = "Triggered when an object is imported")]
    public Task<WebhookResponse<ProjectImportedEvent>> ProjectImportedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<ProjectImportedEvent, ProjectImportedPayload>(webhookRequest, input));
    }

    [Webhook("On project exported", typeof(ProjectExportedHandler),
        Description = "Triggered when a project is exported")]
    public Task<WebhookResponse<ProjectExportedEvent>> ProjectExportedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<ProjectExportedEvent, ProjectExportedPayload>(webhookRequest, input));
    }

    [Webhook("On project deleted", typeof(ProjectDeletedHandler),
        Description = "Triggered when a project is deleted")]
    public Task<WebhookResponse<BaseEvent>> ProjectDeletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input));
    }

    [Webhook("On project snapshot", typeof(ProjectSnapshotHandler),
        Description = "Triggered when a snapshot of a project is made")]
    public Task<WebhookResponse<BaseEvent>> ProjectSnapshotHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input));
    }

    [Webhook("On project branch added", typeof(ProjectBranchAddedHandler),
        Description = "Triggered when a new branch is added to a project")]
    public Task<WebhookResponse<BranchEvent>> ProjectBranchAddedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<BranchEvent, ProjectBranchAddedPayload>(webhookRequest, input));
    }

    [Webhook("On project branch deleted", typeof(ProjectBranchDeletedHandler),
        Description = "Triggered when a branch is deleted from a project")]
    public Task<WebhookResponse<BranchEvent>> ProjectBranchDeletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<BranchEvent, ProjectBranchDeletedPayload>(webhookRequest, input));
    }

    [Webhook("On project branch merged", typeof(ProjectBranchMergedHandler),
        Description = "Triggered when a branch merge happens")]
    public Task<WebhookResponse<BranchMergeEvent>> ProjectBranchMergedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<BranchMergeEvent, ProjectBranchMergedPayload>(webhookRequest, input));
    }

    [Webhook("On languages added", typeof(ProjectLanguagesAddedHandler),
        Description = "Triggered when a new language is added to a project")]
    public Task<WebhookResponse<LanguagesEvent>> ProjectLanguagesAddedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<LanguagesEvent, ProjectLanguagesAddedPayload>(webhookRequest, input));
    }

    [Webhook("On language removed", typeof(ProjectLanguageRemovedHandler),
        Description = "Triggered when a language is removed from a project")]
    public Task<WebhookResponse<LanguageEvent>> ProjectLanguageRemovedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<LanguageEvent, ProjectLanguageRemovedPayload>(webhookRequest, input));
    }

    [Webhook("On language settings changed", typeof(ProjectLanguageSettingsChangedHandler),
        Description = "Triggered when project language settings change")]
    public Task<WebhookResponse<LanguageEvent>> ProjectLanguageSettings_changedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<LanguageEvent, ProjectLanguageSettingsChangedPayload>(webhookRequest, input));
    }

    [Webhook("On key added", typeof(ProjectKeyAddedHandler),
        Description = "Triggered when a new key is added to a project")]
    public async Task<WebhookResponse<GetKeyEvent>> ProjectKeyAddedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        var response = HandlePreflightAndMap<KeyEvent, ProjectKeyAddedPayload>(webhookRequest, input);
        return await MapToEventResponse(response);
    }

    [Webhook("On keys added", typeof(ProjectKeysAddedHandler),
        Description = "Triggered when multiple keys are added to a project")]
    public Task<WebhookResponse<KeysEvent>> ProjectKeysAddedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<KeysEvent, ProjectKeysAddedPayload>(webhookRequest, input));
    }

    [Webhook("On key modified", typeof(ProjectKeyModifiedHandler),
        Description = "Triggered when keys are modified")]
    public async Task<WebhookResponse<GetKeyEvent>> ProjectKeyModifiedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        var response = HandlePreflightAndMap<KeyModifiedEvent, ProjectKeyModifiedPayload>(webhookRequest, input);
        var keyEvent = new KeyEvent
        {
            Key = new KeyWithTags { Id = response.Result.Id },
            ProjectId = response.Result.ProjectId
        };

        return await MapToEventResponse(new WebhookResponse<KeyEvent>
        {
            HttpResponseMessage = response.HttpResponseMessage, 
            Result = keyEvent,
            ReceivedWebhookRequestType = response.ReceivedWebhookRequestType
        });
    }

    [Webhook("On keys deleted", typeof(ProjectKeysDeletedHandler),
        Description = "Triggered when keys are removed from a project")]
    public Task<WebhookResponse<KeysDeletedEvent>> ProjectKeysDeletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<KeysDeletedEvent, ProjectKeysDeletedPayload>(webhookRequest, input));
    }

    [Webhook("On key comment added", typeof(ProjectKeyCommentAddedHandler),
        Description = "Triggers when a new comment is added to a key")]
    public Task<WebhookResponse<KeyCommentEvent>> ProjectKeyCommentAddedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] CommentAddedWebhookInput input)
    {
        var preflightResponse =
            HandlePreflightAndMap<KeyCommentEvent, ProjectKeyCommentAddedPayload>(webhookRequest, input);

        if (preflightResponse.ReceivedWebhookRequestType != WebhookRequestType.Preflight)
        {
            if (input.KeyId != null && preflightResponse.Result.Id != input.KeyId)
            {
                preflightResponse.ReceivedWebhookRequestType = WebhookRequestType.Preflight;
            }
        }

        return Task.FromResult(preflightResponse);
    }

    [Webhook("On translation updated", typeof(ProjectTranslationUpdatedHandler),
        Description = "Triggered when a project translation is updated")]
    public Task<WebhookResponse<TranslationEvent>> ProjectTranslationUpdatedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<TranslationEvent, ProjectTranslationUpdatedPayload>(webhookRequest, input));
    }

    [Webhook("On translations updated", typeof(ProjectTranslationsUpdatedHandler),
        Description = "Triggered when multiple project translations have been updated")]
    public Task<WebhookResponse<TranslationsEvent>> ProjectTranslationsUpdatedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<TranslationsEvent, ProjectTranslationsUpdatedPayload>(webhookRequest, input));
    }

    [Webhook("On translation proofread", typeof(ProjectTranslationProofreadHandler),
        Description = "Triggers when a proofreading has taken place")]
    public Task<WebhookResponse<ProofreadEvent>> ProjectTranslationProofreadHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<ProofreadEvent, ProjectTranslationProofreadPayload>(webhookRequest, input));
    }

    [Webhook("On contributor added", typeof(ProjectContributorAddedHandler),
        Description = "Triggered when a contributor is added to a project")]
    public Task<WebhookResponse<ContributerEvent>> ProjectContributorAddedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<ContributerEvent, ProjectContributorAddedPayload>(webhookRequest, input));
    }

    [Webhook("On contributor deleted", typeof(ProjectContributorDeletedHandler),
        Description = "Triggered when a contributor was deleted from a project")]
    public Task<WebhookResponse<ContributerEvent>> ProjectContributorDeletedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<ContributerEvent, ProjectContributorDeletedPayload>(webhookRequest, input));
    }

    [Webhook("On order created", typeof(TeamOrderCreatedHandler),
        Description = "Triggered when a new team order is created")]
    public Task<WebhookResponse<OrderEvent>> TeamOrderCreatedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<OrderEvent, TeamOrderCreatedPayload>(webhookRequest, input));
    }

    [Webhook("On order deleted", typeof(TeamOrderDeletedHandler),
        Description = "Triggered when a new team order is deleted")]
    public Task<WebhookResponse<BaseEvent>> TeamOrderDeletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input));
    }

    [Webhook("On order completed", typeof(TeamOrderCompletedHandler),
        Description = "Triggered when a new team order is completed")]
    public Task<WebhookResponse<OrderEvent>> TeamOrderCompletedHandler(WebhookRequest webhookRequest,
        [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(HandlePreflightAndMap<OrderEvent, TeamOrderCompletedPayload>(webhookRequest, input));
    }

    [Webhook("On task initial TM leverage calculated",
        typeof(ProjectTaskInitialTmLeverageCalculatedHandler),
        Description = "Triggered when TM calculation finishes")]
    public Task<WebhookResponse<TaskLeverageEvent>> ProjectTaskInitial_tm_leverageCalculatedHandler(
        WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
    {
        return Task.FromResult(
            HandlePreflightAndMap<TaskLeverageEvent, ProjectTaskInitialTmLeverageCalculatedPayload>(
                webhookRequest, input));
    }
}