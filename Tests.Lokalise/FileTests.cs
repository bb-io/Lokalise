using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Files;
using Apps.Lokalise.Models.Requests.Projects;
using LokaliseTests.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Lokalise
{
    [TestClass]
    public class FileTests :TestBase
    {
        [TestMethod]
        public async Task DownloadProjectFilesAsZip_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadProjectFilesAsZip(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" }, 
                new DownloadFileRequest {Format= "json" });
            Assert.IsNotNull(glossary);
        }

        [TestMethod]
        public async Task DownloadProjectFiles_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadProjectSourceFiles(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
                new DownloadSourceFilesRequest { Format = "json" });
            Assert.IsNotNull(glossary);
        }

        [TestMethod]
        public async Task DownloadTranslatedFile_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadTranslatedFile(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
                new DownloadTranslatedFileRequest { Format = "json", LanguageCode="en" , FileName= "no_filename.json" });
            Assert.IsNotNull(glossary);
        }

        [TestMethod]
        public async Task DownloadXLIFFFile_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadXLIFF(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
                new DownloadXLIFFFileRequest { LanguageCode = "en"});
            Assert.IsNotNull(glossary);
        }

        [TestMethod]
        public async Task DownloadXLIFFFromTask_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadXLIFFFromTask(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
                new DownloadXLIFFFileRequest { LanguageCode = "en"});
            Assert.IsNotNull(glossary);
        }

        [TestMethod]
        public async Task DownloadXLIFFAll_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadXLIFFAll(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" },
                new DownloadXLIFFFileRequest { LanguageCode = "en" });
            Assert.IsNotNull(glossary);
        }
    }

}
