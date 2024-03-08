using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests.Tasks
{
    public class FilterRequest
    {
        [Display("Translation reviewed", Description = "Include keys in this task where the translation is reviewed for this target language")]
        public bool? FilterIsReviewed { get; set; }

        [Display("Translation unverified", Description = "Include keys in this task where the translation is unverified for this target language")]
        public bool? FilterUnverified { get; set; }

        [Display("Translation missing", Description = "Include keys in this task where the translation is missing for this target language")]
        public bool? FilterUntranslated { get; set; }
    }
}
