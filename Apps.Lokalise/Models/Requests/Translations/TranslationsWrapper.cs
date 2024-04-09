using Apps.Lokalise.Dtos;
using Apps.Lokalise.Models.Responses.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Lokalise.Models.Requests.Translations
{
    public class TranslationsWrapper : PaginationResponse<TranslationObj>
{
    [JsonProperty("translations")]
    public override IEnumerable<TranslationObj> Items { get; set; }
}
}
