using Blackbird.Applications.Sdk.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class UploadFileRequest
    {
        [Display("Project ID")]
        public string ProjectId { get; set; }
        [Display("File name")]

        public string FileName { get; set; }

        public byte[] File { get; set; }
        [Display("Language code")]

        public string LanguageCode { get; set; }
    }
}
