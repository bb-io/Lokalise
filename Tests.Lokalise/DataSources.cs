using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Keys;
using LokaliseTests.Base;

namespace Tests.Lokalise
{
    [TestClass]
    public class DataSources : TestBase
    {
        [TestMethod]
        public async Task GetKeyReturnsValues()
        {
            var action = new KeyActions(InvocationContext);

            var input = new RetrieveKeyRequest {KeyId= "605456787", ProjectId= "83146869654c5a93e27396.13792235" };
            //var input = new RetrieveKeyRequest { KeyId = "578409547 ", ProjectId = "603260776757017369d310.59884618" };

            var result = await action.RetrieveKey(input);

            Assert.IsNotNull(result);
        }

    }
}
