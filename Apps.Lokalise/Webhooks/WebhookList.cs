using System.Net;
using Apps.Lokalise.Webhooks.Handlers;
using Apps.Lokalise.Webhooks.Payload;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace Apps.Lokalise.Webhooks
{
    [WebhookList]
    public class WebhookList
    {
        const string LokalisePingRequestBody = "[\"ping\"]";

        [Webhook("On project imported", typeof(ProjectImportedHandler),
            Description = "Triggered when an object is imported")]
        public Task<WebhookResponse<ProjectImportedPayload>> ProjectImportedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectImportedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    ReceivedWebhookRequestType = WebhookRequestType.Preflight,
                    Result = null
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectImportedPayload>(webhookRequest.Body.ToString());

            return Task.FromResult(data is not null
                ? new WebhookResponse<ProjectImportedPayload>
                {
                    HttpResponseMessage = null,
                    Result = data
                }
                : throw new InvalidCastException(nameof(webhookRequest.Body)));
        }

        [Webhook("On project exported", typeof(ProjectExportedHandler),
            Description = "Triggered when a project is exported")]
        public Task<WebhookResponse<ProjectExportedPayload>> ProjectExportedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectExportedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectExportedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectExportedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project deleted", typeof(ProjectDeletedHandler),
            Description = "Triggered when a project is deleted")]
        public Task<WebhookResponse<BasePayload>> ProjectDeletedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<BasePayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project snapshot", typeof(ProjectSnapshotHandler),
            Description = "Triggered when a snapshot of a project is made")]
        public Task<WebhookResponse<BasePayload>> ProjectSnapshotHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<BasePayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project branch added", typeof(ProjectBranchAddedHandler),
            Description = "Triggered when a new branch is added to a project")]
        public Task<WebhookResponse<ProjectBranchAddedPayload>> ProjectBranchAddedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectBranchAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectBranchAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectBranchAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project branch deleted", typeof(ProjectBranchDeletedHandler),
            Description = "Triggered when a branch is deleted from a project")]
        public Task<WebhookResponse<ProjectBranchDeletedPayload>> ProjectBranchDeletedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectBranchDeletedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectBranchDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectBranchDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project branch merged", typeof(ProjectBranchMergedHandler),
            Description = "Triggered when a branch merge happens")]
        public Task<WebhookResponse<ProjectBranchMergedPayload>> ProjectBranchMergedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectBranchMergedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectBranchMergedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectBranchMergedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project languages added", typeof(ProjectLanguagesAddedHandler),
            Description = "Triggered when a new language is added to a project")]
        public Task<WebhookResponse<ProjectLanguagesAddedPayload>> ProjectLanguagesAddedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectLanguagesAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectLanguagesAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectLanguagesAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project language removed", typeof(ProjectLanguageRemovedHandler),
            Description = "Triggered when a language is removed from a project")]
        public Task<WebhookResponse<ProjectLanguageRemovedPayload>> ProjectLanguageRemovedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectLanguageRemovedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectLanguageRemovedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectLanguageRemovedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project language settings changed", typeof(ProjectLanguageSettingsChangedHandler),
            Description = "Triggered when project language settings change")]
        public Task<WebhookResponse<ProjectLanguageSettingsChangedPayload>>
            ProjectLanguageSettings_changedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectLanguageSettingsChangedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data =
                JsonConvert.DeserializeObject<ProjectLanguageSettingsChangedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectLanguageSettingsChangedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project key added", typeof(ProjectKeyAddedHandler),
            Description = "Triggered when a new key is added to a project")]
        public Task<WebhookResponse<ProjectKeyAddedPayload>> ProjectKeyAddedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectKeyAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectKeyAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectKeyAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project keys added", typeof(ProjectKeysAddedHandler),
            Description = "Triggered when multiple keys are added to a project")]
        public Task<WebhookResponse<ProjectKeysAddedPayload>> ProjectKeysAddedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectKeysAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectKeysAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectKeysAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project key modified", typeof(ProjectKeyModifiedHandler),
            Description = "Triggered when keys are modified")]
        public Task<WebhookResponse<ProjectKeyModifiedPayload>> ProjectKeyModifiedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectKeyModifiedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectKeyModifiedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectKeyModifiedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project keys deleted", typeof(ProjectKeysDeletedHandler),
            Description = "Triggered when keys are removed from a project")]
        public Task<WebhookResponse<ProjectKeysDeletedPayload>> ProjectKeysDeletedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectKeysDeletedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectKeysDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectKeysDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project key comment added", typeof(ProjectKeyCommentAddedHandler),
            Description = "Triggers when a new comment is added to a key")]
        public Task<WebhookResponse<ProjectKeyCommentAddedPayload>> ProjectKeyCommentAddedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectKeyCommentAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectKeyCommentAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectKeyCommentAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project translation updated", typeof(ProjectTranslationUpdatedHandler),
            Description = "Triggered when a project translation is updated")]
        public Task<WebhookResponse<ProjectTranslationUpdatedPayload>> ProjectTranslationUpdatedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectTranslationUpdatedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTranslationUpdatedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectTranslationUpdatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project translations updated", typeof(ProjectTranslationsUpdatedHandler),
            Description = "Triggered when multiple project translations have been updated")]
        public Task<WebhookResponse<ProjectTranslationsUpdatedPayload>> ProjectTranslationsUpdatedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectTranslationsUpdatedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTranslationsUpdatedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectTranslationsUpdatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project translation proofread", typeof(ProjectTranslationProofreadHandler),
            Description = "Triggers when a proofreading has taken place")]
        public Task<WebhookResponse<ProjectTranslationProofreadPayload>> ProjectTranslationProofreadHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectTranslationProofreadPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data =
                JsonConvert.DeserializeObject<ProjectTranslationProofreadPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectTranslationProofreadPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project contributor added", typeof(ProjectContributorAddedHandler),
            Description = "Triggered when a contributor is added to a project")]
        public Task<WebhookResponse<ProjectContributorAddedPayload>> ProjectContributorAddedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectContributorAddedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectContributorAddedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectContributorAddedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project contributor deleted", typeof(ProjectContributorDeletedHandler),
            Description = "Triggered when a contributor was deleted from a project")]
        public Task<WebhookResponse<ProjectContributorDeletedPayload>> ProjectContributorDeletedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectContributorDeletedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectContributorDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectContributorDeletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project task created", typeof(ProjectTaskCreatedHandler),
            Description = "Triggered when a new task is created in a project")]
        public Task<WebhookResponse<Lokalise.Webhooks.Payload.Task>> ProjectTaskCreatedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTaskCreatedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
            {
                HttpResponseMessage = null,
                Result = data.Task
            });
        }

        [Webhook("On project task closed", typeof(ProjectTaskClosedHandler),
            Description = "Triggered when a project task is closed")]
        public Task<WebhookResponse<Lokalise.Webhooks.Payload.Task>> ProjectTaskClosedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTaskClosedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
            {
                HttpResponseMessage = null,
                Result = data.Task
            });
        }

        [Webhook("On project task deleted", typeof(ProjectTaskDeletedHandler),
            Description = "Triggered when a project task is deleted")]
        public Task<WebhookResponse<Lokalise.Webhooks.Payload.Task>> ProjectTaskDeletedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTaskDeletedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<Lokalise.Webhooks.Payload.Task>
            {
                HttpResponseMessage = null,
                Result = data.Task
            });
        }

        [Webhook("On project task language closed", typeof(ProjectTaskLanguageClosedHandler),
            Description = "Triggered when a specific language task closes")]
        public Task<WebhookResponse<ProjectTaskLanguageClosedPayload>> ProjectTaskLanguageClosedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectTaskLanguageClosedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<ProjectTaskLanguageClosedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectTaskLanguageClosedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On team order created", typeof(TeamOrderCreatedHandler),
            Description = "Triggered when a new team order is created")]
        public Task<WebhookResponse<TeamOrderCreatedPayload>> TeamOrderCreatedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<TeamOrderCreatedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<TeamOrderCreatedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<TeamOrderCreatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On team order deleted", typeof(TeamOrderDeletedHandler),
            Description = "Triggered when a new team order is deleted")]
        public Task<WebhookResponse<BasePayload>> TeamOrderDeletedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<BasePayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<BasePayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<BasePayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On team order completed", typeof(TeamOrderCompletedHandler),
            Description = "Triggered when a new team order is completed")]
        public Task<WebhookResponse<TeamOrderCompletedPayload>> TeamOrderCompletedHandler(
            WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<TeamOrderCompletedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data = JsonConvert.DeserializeObject<TeamOrderCompletedPayload>(webhookRequest.Body.ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<TeamOrderCompletedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }

        [Webhook("On project task initial TM leverage calculated",
            typeof(ProjectTaskInitial_tm_leverageCalculatedHandler),
            Description = "Triggered when TM calculation finishes")]
        public Task<WebhookResponse<ProjectTaskInitialTmLeverageCalculatedPayload>>
            ProjectTaskInitial_tm_leverageCalculatedHandler(WebhookRequest webhookRequest)
        {
            if (webhookRequest.Body.ToString() == LokalisePingRequestBody)
            {
                return Task.FromResult(new WebhookResponse<ProjectTaskInitialTmLeverageCalculatedPayload>
                {
                    HttpResponseMessage = new HttpResponseMessage(statusCode: HttpStatusCode.OK),
                    Result = null, ReceivedWebhookRequestType = WebhookRequestType.Preflight
                });
            }

            var data =
                JsonConvert.DeserializeObject<ProjectTaskInitialTmLeverageCalculatedPayload>(webhookRequest.Body
                    .ToString());
            if (data is null)
            {
                throw new InvalidCastException(nameof(webhookRequest.Body));
            }

            return Task.FromResult(new WebhookResponse<ProjectTaskInitialTmLeverageCalculatedPayload>
            {
                HttpResponseMessage = null,
                Result = data
            });
        }
    }
}