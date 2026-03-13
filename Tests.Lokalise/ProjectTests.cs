using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Projects;
using LokaliseTests.Base;

namespace Tests.Lokalise
{
    [TestClass]
    public class ProjectTests : TestBase
    {
        [TestMethod]
        public async Task GetProject_IsSuccess()
        {
            var action = new ProjectActions(InvocationContext);
            var response = await action.RetrieveProject(new ProjectRequest 
            { 
               // ProjectId = "43255416680bccef893775.42965789", 
                ProjectId = "8503304169984f8be345c5.11466314"
            });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(response));
            Assert.IsNotNull(response);
        }
    }
}
