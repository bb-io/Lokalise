using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class DeleteLanguageFromProjectRequest
    {
        public string ProjectId { get; set; }

        public string LanguageId { get; set; }
    }
}
