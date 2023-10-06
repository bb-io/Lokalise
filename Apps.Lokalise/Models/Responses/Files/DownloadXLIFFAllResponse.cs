using Blackbird.Applications.Sdk.Common.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = Blackbird.Applications.Sdk.Common.Files.File;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class DownloadXLIFFAllResponse
    {
        public List<File> Files { get; set; }
    }
}
