using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common.Files;
using LokaliseTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Lokalise
{
    [TestClass]
    public class GlossaryTests :TestBase
    {
        [TestMethod]
        public async Task ExporttGlossary_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);

            var glossary = await action.ExportGlossaryTerms(new ProjectRequest { ProjectId= "43255416680bccef893775.42965789" });

            Assert.IsNotNull(glossary);
        }


        [TestMethod]
        public async Task ImportGlossary_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);

            var glossary = await action.ImportGlossary(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789"}, 
                new FileReference { Name = "test.tbx" });

            Assert.IsNotNull(glossary);
        }
    }
}
