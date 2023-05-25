using Apps.Lokalise.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Responses.Languages
{
    public class ListLanguagesResponse
    {
        public IEnumerable<LanguageDto> Languages { get; set; }
    }
}
