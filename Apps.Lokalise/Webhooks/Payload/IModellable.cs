using Apps.Lokalise.Webhooks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Webhooks.Payload
{
    public interface IModellable
    {
        public BaseEvent Convert();
    }
}
