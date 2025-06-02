using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Projects;
using Apps.Lokalise.Models.Requests.Translations;
using LokaliseTests.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Lokalise
{
    [TestClass]
    public class TranslationTests :TestBase
    {
        [TestMethod]
        public async Task GetProjectTranslations_IsSuccess()
        {
            var action = new TranslationActions(InvocationContext);
            var translations = await action.ListTranslations(new ListTranslationRequest { ProjectId = "43255416680bccef893775.42965789" },
                new ListTranslationQueryRequest { });

            string jsonResponse = JsonConvert.SerializeObject(translations, Formatting.Indented);
            Console.WriteLine(jsonResponse);
            Assert.IsNotNull(translations);
        }
    }
}
