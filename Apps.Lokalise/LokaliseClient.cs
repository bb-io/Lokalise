using Apps.Lokalise.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise
{
    public class LokaliseClient : RestClient
    {
        public LokaliseClient() : base(new RestClientOptions() { ThrowOnAnyError = true, BaseUrl = new Uri("https://api.lokalise.com/api2/") }) { }


        public QueuedProcessDto PollFileImportOperation(string projectId, string processId,
            IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            var request = new LokaliseRequest($"/projects/{projectId}/processes/{processId}",
                Method.Get, authenticationCredentialsProviders);
            var response = this.Get<QueuedProcessDto>(request);
            while (response?.Process.Status != "finished")
            {
                Task.Delay(2000);
                response = this.Get<QueuedProcessDto>(request);
            }
            return response;
        }
    }
}
