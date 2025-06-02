using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Keys;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Glossaries.Utils.Dtos;
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
    public class KeyTests:TestBase
    {
        [TestMethod]
        public async Task GetProjectKeys_IsSuccess()
        {
            var action = new KeyActions(InvocationContext);
            var keys = await action.GetProjectKeys(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
            new ListProjectKeysRequest(), new ListProjectKeysFilters());

            string jsonResponse = JsonConvert.SerializeObject(keys, Formatting.Indented);
            Console.WriteLine(jsonResponse);
            Assert.IsNotNull(keys);
        }
    }
}
