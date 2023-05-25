﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests
{
    public class DownloadTranslatedFileRequest
    {
        public string ProjectId { get; set; }
        public string FileName { get; set; }
        public string FileFormat { get; set; }

        public string LanguageCode { get; set; }
    }
}
