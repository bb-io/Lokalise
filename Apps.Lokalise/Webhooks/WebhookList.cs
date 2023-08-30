using System.Net;
using Apps.Lokalise.Webhooks.Handlers;
using Apps.Lokalise.Webhooks.Models;
using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using RestSharp;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks
{
    [WebhookList]
    public class WebhookList : BaseInvocable
    {
        const string LokalisePingRequestBody = "[\"ping\"]";

        public WebhookList(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        private WebhookResponse<T1> HandlePreflightAndMap<T1, T2>(WebhookRequest webhookRequest, WebhookInput input)
            where T2 : BasePayload where T1 : BaseEvent
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return new()
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null,
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight
                };
            }
            var data = JsonConvert.DeserializeObject<T2>(webhookRequest.Body.ToString()!);
            if (data is null)
                throw new InvalidCastException(nameof(webhookRequest.Body));

            if (data.Project.Id != input.ProjectId)
            {
                return new()
                {
                    HttpResponseMessage = null,
                    Result = null,
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight
                };
            }
            return new()
            {
                HttpResponseMessage = null,
                Result = (T1)data.Convert()
            };
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

        [Webhook("On project languages added", typeof(ProjectLanguagesAddedHandler),
            Description = "Triggered when a new language is added to a project")]
        public Task<WebhookResponse<LanguagesEvent>> ProjectLanguagesAddedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<LanguagesEvent, ProjectLanguagesAddedPayload>(webhookRequest, input));
        }

        [Webhook("On project language removed", typeof(ProjectLanguageRemovedHandler),
            Description = "Triggered when a language is removed from a project")]
        public Task<WebhookResponse<LanguageEvent>> ProjectLanguageRemovedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<LanguageEvent, ProjectLanguageRemovedPayload>(webhookRequest, input));
        }

        [Webhook("On project language settings changed", typeof(ProjectLanguageSettingsChangedHandler),
            Description = "Triggered when project language settings change")]
        public Task<WebhookResponse<LanguageEvent>> ProjectLanguageSettings_changedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<LanguageEvent, ProjectLanguageSettingsChangedPayload>(webhookRequest, input));
        }

        [Webhook("On project key added", typeof(ProjectKeyAddedHandler),
            Description = "Triggered when a new key is added to a project")]
        public Task<WebhookResponse<KeyEvent>> ProjectKeyAddedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<KeyEvent, ProjectKeyAddedPayload>(webhookRequest, input));
        }

        [Webhook("On project keys added", typeof(ProjectKeysAddedHandler),
            Description = "Triggered when multiple keys are added to a project")]
        public Task<WebhookResponse<KeysEvent>> ProjectKeysAddedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<KeysEvent, ProjectKeysAddedPayload>(webhookRequest, input));
        }

        [Webhook("On project key modified", typeof(ProjectKeyModifiedHandler),
            Description = "Triggered when keys are modified")]
        public Task<WebhookResponse<KeyModifiedEvent>> ProjectKeyModifiedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<KeyModifiedEvent, ProjectKeyModifiedPayload>(webhookRequest, input));
        }

        [Webhook("On project keys deleted", typeof(ProjectKeysDeletedHandler),
            Description = "Triggered when keys are removed from a project")]
        public Task<WebhookResponse<KeysDeletedEvent>> ProjectKeysDeletedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<KeysDeletedEvent, ProjectKeysDeletedPayload>(webhookRequest, input));
        }

        [Webhook("On project key comment added", typeof(ProjectKeyCommentAddedHandler),
            Description = "Triggers when a new comment is added to a key")]
        public Task<WebhookResponse<KeyCommentEvent>> ProjectKeyCommentAddedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<KeyCommentEvent, ProjectKeyCommentAddedPayload>(webhookRequest, input));
        }

        [Webhook("On project translation updated", typeof(ProjectTranslationUpdatedHandler),
            Description = "Triggered when a project translation is updated")]
        public Task<WebhookResponse<TranslationEvent>> ProjectTranslationUpdatedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<TranslationEvent, ProjectTranslationUpdatedPayload>(webhookRequest, input));
        }

        [Webhook("On project translations updated", typeof(ProjectTranslationsUpdatedHandler),
            Description = "Triggered when multiple project translations have been updated")]
        public Task<WebhookResponse<TranslationsEvent>> ProjectTranslationsUpdatedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<TranslationsEvent, ProjectTranslationsUpdatedPayload>(webhookRequest, input));
        }

        [Webhook("On project translation proofread", typeof(ProjectTranslationProofreadHandler),
            Description = "Triggers when a proofreading has taken place")]
        public Task<WebhookResponse<ProofreadEvent>> ProjectTranslationProofreadHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<ProofreadEvent, ProjectTranslationProofreadPayload>(webhookRequest, input));
        }

        [Webhook("On project contributor added", typeof(ProjectContributorAddedHandler),
            Description = "Triggered when a contributor is added to a project")]
        public Task<WebhookResponse<ContributerEvent>> ProjectContributorAddedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<ContributerEvent, ProjectContributorAddedPayload>(webhookRequest, input));
        }

        [Webhook("On project contributor deleted", typeof(ProjectContributorDeletedHandler),
            Description = "Triggered when a contributor was deleted from a project")]
        public Task<WebhookResponse<ContributerEvent>> ProjectContributorDeletedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<ContributerEvent, ProjectContributorDeletedPayload>(webhookRequest, input));
        }

        [Webhook("On project task created", typeof(ProjectTaskCreatedHandler),
            Description = "Triggered when a new task is created in a project")]
        public Task<WebhookResponse<TaskEvent>> ProjectTaskCreatedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<TaskEvent, ProjectTaskCreatedPayload>(webhookRequest, input));
        }

        [Webhook("On project task closed", typeof(ProjectTaskClosedHandler),
            Description = "Triggered when a project task is closed")]
        public Task<WebhookResponse<TaskEvent>> ProjectTaskClosedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<TaskEvent, ProjectTaskClosedPayload>(webhookRequest, input));
        }

        [Webhook("On project task deleted", typeof(ProjectTaskDeletedHandler),
            Description = "Triggered when a project task is deleted")]
        public Task<WebhookResponse<TaskEvent>> ProjectTaskDeletedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<TaskEvent, ProjectTaskDeletedPayload>(webhookRequest, input));
        }

        [Webhook("On project task language closed", typeof(ProjectTaskLanguageClosedHandler),
            Description = "Triggered when a specific language task closes")]
        public Task<WebhookResponse<TaskLanguageEvent>> ProjectTaskLanguageClosedHandler(
            WebhookRequest webhookRequest, [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(
                HandlePreflightAndMap<TaskLanguageEvent, ProjectTaskLanguageClosedPayload>(webhookRequest, input));
        }

        [Webhook("On team order created", typeof(TeamOrderCreatedHandler),
            Description = "Triggered when a new team order is created")]
        public Task<WebhookResponse<OrderEvent>> TeamOrderCreatedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<OrderEvent, TeamOrderCreatedPayload>(webhookRequest, input));
        }

        [Webhook("On team order deleted", typeof(TeamOrderDeletedHandler),
            Description = "Triggered when a new team order is deleted")]
        public Task<WebhookResponse<BaseEvent>> TeamOrderDeletedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input));
        }

        [Webhook("On team order completed", typeof(TeamOrderCompletedHandler),
            Description = "Triggered when a new team order is completed")]
        public Task<WebhookResponse<OrderEvent>> TeamOrderCompletedHandler(WebhookRequest webhookRequest,
            [WebhookParameter(true)] WebhookInput input)
        {
            return Task.FromResult(HandlePreflightAndMap<OrderEvent, TeamOrderCompletedPayload>(webhookRequest, input));
        }

        [Webhook("On project task initial TM leverage calculated",
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
}