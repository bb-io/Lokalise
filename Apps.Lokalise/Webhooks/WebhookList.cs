
using Apps.Lokalise.Webhooks.Handlers;
using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using System.Text.Json;

namespace Apps.Localise.Webhooks
{
    [WebhookList]
    public class WebhookList 
    {

        [Webhook("On project imported", typeof(ProjectImportedHandler))]
        public async Task<WebhookResponse<ProjectImportedPayload>> ProjectImportedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectImportedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectImportedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project exported", typeof(ProjectExportedHandler))]
        public async Task<WebhookResponse<ProjectExportedPayload>> ProjectExportedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectExportedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectExportedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project deleted", typeof(ProjectDeletedHandler))]
        public async Task<WebhookResponse<BasePayload>> ProjectDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project snapshot", typeof(ProjectSnapshotHandler))]
        public async Task<WebhookResponse<BasePayload>> ProjectSnapshotHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project branch added", typeof(ProjectBranchAddedHandler))]
        public async Task<WebhookResponse<ProjectBranchAddedPayload>> ProjectBranchAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectBranchAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectBranchAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project branch deleted", typeof(ProjectBranchDeletedHandler))]
        public async Task<WebhookResponse<ProjectBranchDeletedPayload>> ProjectBranchDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectBranchDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectBranchDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project branch merged", typeof(ProjectBranchMergedHandler))]
        public async Task<WebhookResponse<ProjectBranchMergedPayload>> ProjectBranchMergedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectBranchMergedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectBranchMergedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project languages added", typeof(ProjectLanguagesAddedHandler))]
        public async Task<WebhookResponse<ProjectLanguagesAddedPayload>> ProjectLanguagesAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectLanguagesAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectLanguagesAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project language removed", typeof(ProjectLanguageRemovedHandler))]
        public async Task<WebhookResponse<ProjectLanguageRemovedPayload>> ProjectLanguageRemovedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectLanguageRemovedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectLanguageRemovedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project language settings changed", typeof(ProjectLanguageSettings_changedHandler))]
        public async Task<WebhookResponse<ProjectLanguageSettings_changedPayload>> ProjectLanguageSettings_changedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectLanguageSettings_changedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectLanguageSettings_changedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project key added", typeof(ProjectKeyAddedHandler))]
        public async Task<WebhookResponse<ProjectKeyAddedPayload>> ProjectKeyAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectKeyAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectKeyAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project keys added", typeof(ProjectKeysAddedHandler))]
        public async Task<WebhookResponse<ProjectKeysAddedPayload>> ProjectKeysAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectKeysAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectKeysAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project key modified", typeof(ProjectKeyModifiedHandler))]
        public async Task<WebhookResponse<ProjectKeyModifiedPayload>> ProjectKeyModifiedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectKeyModifiedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project keys deleted", typeof(ProjectKeysDeletedHandler))]
        public async Task<WebhookResponse<ProjectKeysDeletedPayload>> ProjectKeysDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectKeysDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectKeysDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project key comment added", typeof(ProjectKeyCommentAddedHandler))]
        public async Task<WebhookResponse<ProjectKeyCommentAddedPayload>> ProjectKeyCommentAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectKeyCommentAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectKeyCommentAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project translation updated", typeof(ProjectTranslationUpdatedHandler))]
        public async Task<WebhookResponse<ProjectTranslationUpdatedPayload>> ProjectTranslationUpdatedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTranslationUpdatedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTranslationUpdatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project translations updated", typeof(ProjectTranslationsUpdatedHandler))]
        public async Task<WebhookResponse<ProjectTranslationsUpdatedPayload>> ProjectTranslationsUpdatedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTranslationsUpdatedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTranslationsUpdatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project translation proofread", typeof(ProjectTranslationProofreadHandler))]
        public async Task<WebhookResponse<ProjectTranslationProofreadPayload>> ProjectTranslationProofreadHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTranslationProofreadPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTranslationProofreadPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project contributor added", typeof(ProjectContributorAddedHandler))]
        public async Task<WebhookResponse<ProjectContributorAddedPayload>> ProjectContributorAddedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectContributorAddedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectContributorAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project contributor deleted", typeof(ProjectContributorDeletedHandler))]
        public async Task<WebhookResponse<ProjectContributorDeletedPayload>> ProjectContributorDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectContributorDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectContributorDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project task created", typeof(ProjectTaskCreatedHandler))]
        public async Task<WebhookResponse<ProjectTaskCreatedPayload>> ProjectTaskCreatedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTaskCreatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project task closed", typeof(ProjectTaskClosedHandler))]
        public async Task<WebhookResponse<ProjectTaskClosedPayload>> ProjectTaskClosedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTaskClosedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTaskClosedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project task deleted", typeof(ProjectTaskDeletedHandler))]
        public async Task<WebhookResponse<ProjectTaskDeletedPayload>> ProjectTaskDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTaskDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTaskDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project task language closed", typeof(ProjectTaskLanguageClosedHandler))]
        public async Task<WebhookResponse<ProjectTaskLanguageClosedPayload>> ProjectTaskLanguageClosedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTaskLanguageClosedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTaskLanguageClosedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On team order created", typeof(TeamOrderCreatedHandler))]
        public async Task<WebhookResponse<TeamOrderCreatedPayload>> TeamOrderCreatedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<TeamOrderCreatedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<TeamOrderCreatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On team order deleted", typeof(TeamOrderDeletedHandler))]
        public async Task<WebhookResponse<BasePayload>> TeamOrderDeletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On team order completed", typeof(TeamOrderCompletedHandler))]
        public async Task<WebhookResponse<TeamOrderCompletedPayload>> TeamOrderCompletedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<TeamOrderCompletedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<TeamOrderCompletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

        [Webhook("On project task initial tm leverage calculated", typeof(ProjectTaskInitial_tm_leverageCalculatedHandler))]
        public async Task<WebhookResponse<ProjectTaskInitial_tm_leverageCalculatedPayload>> ProjectTaskInitial_tm_leverageCalculatedHandler(WebhookRequest webhookRequest)
        {
            var data = JsonConvert.DeserializeObject<ProjectTaskInitial_tm_leverageCalculatedPayload>(webhookRequest.Body.ToString());
            if (data is null) { throw new InvalidCastException(nameof(webhookRequest.Body)); }
            return new WebhookResponse<ProjectTaskInitial_tm_leverageCalculatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            };
        }

    }
}
