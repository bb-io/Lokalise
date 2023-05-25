using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class LanguageDto
    {
        public string Lang_id { get; set; }

        public string Lang_iso { get; set; }
        public string Lang_name { get; set; }
        public string Is_rtl { get; set; }

    }
}
