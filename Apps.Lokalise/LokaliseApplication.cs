using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise
{
    public class LokaliseApplication : IApplication
    {
        public string Name
        {
            get => "Lokalise";
            set { }
        }

        public T GetInstance<T>()
        {
            throw new NotImplementedException();
        }
    }
}
