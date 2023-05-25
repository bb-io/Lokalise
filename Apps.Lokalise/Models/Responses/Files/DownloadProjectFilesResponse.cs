using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class DownloadProjectFilesResponse
    {
        public string FileName { get; set; }

        public byte[] File { get; set; }
    }
}
