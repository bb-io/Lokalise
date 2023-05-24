using Apps.Lokalise.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Responses.Files
{
    public class FilesWrapper
    {
        public IEnumerable<FileInfoDto> Files { get; set; }
    }
}
