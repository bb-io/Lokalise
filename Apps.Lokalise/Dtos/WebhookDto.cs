using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class WebhookDto
    {
        public string WebhookId { get; set; }
        public string Url { get; set; }
        public object Branch { get; set; }
        public string Secret { get; set; }
        public List<string> Events { get; set; }
    }

    public class WebhooksResponseWrapper
    {
        public IEnumerable<WebhookDto> Webhooks { get; set; }
    }
}
