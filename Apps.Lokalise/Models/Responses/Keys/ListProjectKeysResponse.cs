using Apps.Lokalise.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Responses.Keys
{
    public class ListProjectKeysResponse
    {
        public IEnumerable<KeyDto> Keys { get; set; }
    }
}
