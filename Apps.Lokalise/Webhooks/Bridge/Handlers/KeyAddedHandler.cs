using Apps.Lokalise.Webhooks.Bridge.Base;
using Apps.Lokalise.Webhooks.Bridge.Base.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Bridge.Handlers
{
    public class KeyAddedHandler : BaseWebhookBridgeHandler
    {
        public static string Event => "project.key.added";

        public KeyAddedHandler(InvocationContext invocationContext, [WebhookParameter] ProjectInputOption projectInfo):base(invocationContext, Event, projectInfo.ProjectId)
        {

        }
    }
}
