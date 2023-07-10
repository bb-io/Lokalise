using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Dtos
{
    public class FileInfoDto
    {
        [Display("File ID")]
        public string File_id { get; set; }

        [Display("Filename")]
        public string Filename { get; set; }

        [Display("Key count")]
        public int Key_count { get; set; }
    }
}
