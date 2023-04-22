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
    }
}
