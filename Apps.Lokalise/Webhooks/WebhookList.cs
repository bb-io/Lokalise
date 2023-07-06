
using Apps.Lokalise.Webhooks;
using Apps.Lokalise.Webhooks.Handlers;
using Apps.Lokalise.Webhooks.Models;
using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using System.Net;
using System.Text.Json;

namespace Apps.Localise.Webhooks
{
    [WebhookList]
    public class WebhookList 
    {
        const string LokalisePingRequestBody = "[\"ping\"]";

        private WebhookResponse<T1> HandlePreflightAndMap<T1, T2>(WebhookRequest webhookRequest, WebhookInput input) where T2 : BasePayload where T1 : BaseEvent
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return new WebhookResponse<T1>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null,
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight
                };
            }
            var data = JsonConvert.DeserializeObject<T2>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }

            if (data.Project.Id != input.ProjectId)
            {
                return new WebhookResponse<T1>
                {
                    HttpResponseMessage = null,
                    Result = null,
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight
                };
            }

            return new WebhookResponse<T1>
            {
                HttpResponseMessage = null,
                Result = (T1) data.Convert()
            };
        }

        [Webhook("On project imported", typeof(ProjectImportedHandler), Description = "Triggered when an object is imported")]
        public async Task<WebhookResponse<ProjectImportedEvent>> ProjectImportedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<ProjectImportedEvent, ProjectImportedPayload>(webhookRequest, input);
        }

        [Webhook("On project exported", typeof(ProjectExportedHandler), Description = "Triggered when a project is exported")]
        public async Task<WebhookResponse<ProjectExportedEvent>> ProjectExportedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<ProjectExportedEvent, ProjectExportedPayload>(webhookRequest, input);
        }

        [Webhook("On project deleted", typeof(ProjectDeletedHandler), Description = "Triggered when a project is deleted")]
        public async Task<WebhookResponse<BaseEvent>> ProjectDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input);
        }

        [Webhook("On project snapshot", typeof(ProjectSnapshotHandler), Description = "Triggered when a snapshot of a project is made")]
        public async Task<WebhookResponse<BaseEvent>> ProjectSnapshotHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input);
        }

        [Webhook("On project branch added", typeof(ProjectBranchAddedHandler), Description = "Triggered when a new branch is added to a project")]
        public async Task<WebhookResponse<BranchEvent>> ProjectBranchAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BranchEvent, ProjectBranchAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project branch deleted", typeof(ProjectBranchDeletedHandler), Description = "Triggered when a branch is deleted from a project")]
        public async Task<WebhookResponse<BranchEvent>> ProjectBranchDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BranchEvent, ProjectBranchDeletedPayload>(webhookRequest, input);
        }

        [Webhook("On project branch merged", typeof(ProjectBranchMergedHandler), Description = "Triggered when a branch merge happens")]
        public async Task<WebhookResponse<BranchMergeEvent>> ProjectBranchMergedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BranchMergeEvent, ProjectBranchMergedPayload>(webhookRequest, input);
        }

        [Webhook("On project languages added", typeof(ProjectLanguagesAddedHandler), Description = "Triggered when a new language is added to a project")]
        public async Task<WebhookResponse<LanguagesEvent>> ProjectLanguagesAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<LanguagesEvent, ProjectLanguagesAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project language removed", typeof(ProjectLanguageRemovedHandler), Description = "Triggered when a language is removed from a project")]
        public async Task<WebhookResponse<LanguageEvent>> ProjectLanguageRemovedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<LanguageEvent, ProjectLanguageRemovedPayload>(webhookRequest, input);
        }

        [Webhook("On project language settings changed", typeof(ProjectLanguageSettings_changedHandler), Description = "Triggered when project language settings change")]
        public async Task<WebhookResponse<LanguageEvent>> ProjectLanguageSettings_changedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<LanguageEvent, ProjectLanguageSettings_changedPayload>(webhookRequest, input);
        }

        [Webhook("On project key added", typeof(ProjectKeyAddedHandler), Description = "Triggered when a new key is added to a project")]
        public async Task<WebhookResponse<KeyEvent>> ProjectKeyAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<KeyEvent, ProjectKeyAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project keys added", typeof(ProjectKeysAddedHandler), Description = "Triggered when multiple keys are added to a project")]
        public async Task<WebhookResponse<KeysEvent>> ProjectKeysAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<KeysEvent, ProjectKeysAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project key modified", typeof(ProjectKeyModifiedHandler), Description = "Triggered when keys are modified")]
        public async Task<WebhookResponse<KeyModifiedEvent>> ProjectKeyModifiedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<KeyModifiedEvent, ProjectKeyModifiedPayload>(webhookRequest, input);
        }

        [Webhook("On project keys deleted", typeof(ProjectKeysDeletedHandler), Description = "Triggered when keys are removed from a project")]
        public async Task<WebhookResponse<KeysDeletedEvent>> ProjectKeysDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<KeysDeletedEvent, ProjectKeysDeletedPayload>(webhookRequest, input);
        }

        [Webhook("On project key comment added", typeof(ProjectKeyCommentAddedHandler), Description = "Triggers when a new comment is added to a key")]
        public async Task<WebhookResponse<KeyCommentEvent>> ProjectKeyCommentAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<KeyCommentEvent, ProjectKeyCommentAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project translation updated", typeof(ProjectTranslationUpdatedHandler), Description = "Triggered when a project translation is updated")]
        public async Task<WebhookResponse<TranslationEvent>> ProjectTranslationUpdatedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TranslationEvent, ProjectTranslationUpdatedPayload>(webhookRequest, input);
        }

        [Webhook("On project translations updated", typeof(ProjectTranslationsUpdatedHandler), Description = "Triggered when multiple project translations have been updated")]
        public async Task<WebhookResponse<TranslationsEvent>> ProjectTranslationsUpdatedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TranslationsEvent, ProjectTranslationsUpdatedPayload>(webhookRequest, input);
        }

        [Webhook("On project translation proofread", typeof(ProjectTranslationProofreadHandler), Description = "Triggers when a proofreading has taken place")]
        public async Task<WebhookResponse<ProofreadEvent>> ProjectTranslationProofreadHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<ProofreadEvent, ProjectTranslationProofreadPayload>(webhookRequest, input);
        }

        [Webhook("On project contributor added", typeof(ProjectContributorAddedHandler), Description = "Triggered when a contributor is added to a project")]
        public async Task<WebhookResponse<ContributerEvent>> ProjectContributorAddedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<ContributerEvent, ProjectContributorAddedPayload>(webhookRequest, input);
        }

        [Webhook("On project contributor deleted", typeof(ProjectContributorDeletedHandler), Description = "Triggered when a contributor was deleted from a project")]
        public async Task<WebhookResponse<ContributerEvent>> ProjectContributorDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<ContributerEvent, ProjectContributorDeletedPayload>(webhookRequest, input);
        }

        [Webhook("On project task created", typeof(ProjectTaskCreatedHandler), Description = "Triggered when a new task is created in a project")]
        public async Task<WebhookResponse<TaskEvent>> ProjectTaskCreatedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TaskEvent, ProjectTaskCreatedPayload>(webhookRequest, input);
        }               

        [Webhook("On project task closed", typeof(ProjectTaskClosedHandler), Description = "Triggered when a project task is closed")]
        public async Task<WebhookResponse<TaskEvent>> ProjectTaskClosedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TaskEvent, ProjectTaskClosedPayload>(webhookRequest, input);
        }        

        [Webhook("On project task deleted", typeof(ProjectTaskDeletedHandler), Description = "Triggered when a project task is deleted")]
        public async Task<WebhookResponse<TaskEvent>> ProjectTaskDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TaskEvent, ProjectTaskDeletedPayload>(webhookRequest, input);
        }

        [Webhook("On project task language closed", typeof(ProjectTaskLanguageClosedHandler), Description = "Triggered when a specific language task closes")]
        public async Task<WebhookResponse<TaskLanguageEvent>> ProjectTaskLanguageClosedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TaskLanguageEvent, ProjectTaskLanguageClosedPayload>(webhookRequest, input);
        }

        [Webhook("On team order created", typeof(TeamOrderCreatedHandler), Description = "Triggered when a new team order is created")]
        public async Task<WebhookResponse<OrderEvent>> TeamOrderCreatedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<OrderEvent, TeamOrderCreatedPayload>(webhookRequest, input);
        }

        [Webhook("On team order deleted", typeof(TeamOrderDeletedHandler), Description = "Triggered when a new team order is deleted")]
        public async Task<WebhookResponse<BaseEvent>> TeamOrderDeletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<BaseEvent, BasePayload>(webhookRequest, input);
        }

        [Webhook("On team order completed", typeof(TeamOrderCompletedHandler), Description = "Triggered when a new team order is completed")]
        public async Task<WebhookResponse<OrderEvent>> TeamOrderCompletedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<OrderEvent, TeamOrderCompletedPayload>(webhookRequest, input);
        }

        [Webhook("On project task initial TM leverage calculated", typeof(ProjectTaskInitial_tm_leverageCalculatedHandler), Description = "Triggered when TM calculation finishes")]
        public async Task<WebhookResponse<TaskLeverageEvent>> ProjectTaskInitial_tm_leverageCalculatedHandler(WebhookRequest webhookRequest, [WebhookParameter] WebhookInput input)
        {
            return HandlePreflightAndMap<TaskLeverageEvent, ProjectTaskInitial_tm_leverageCalculatedPayload>(webhookRequest, input);
        }
    }
}
