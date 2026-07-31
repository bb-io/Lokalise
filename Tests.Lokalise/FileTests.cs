using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Files;
using Apps.Lokalise.Models.Requests.Projects;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using LokaliseTests.Base;
using Moq;
using Newtonsoft.Json;
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
        public async Task UploadFileToMarketingProject_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var result = await action.UploadFileToMarketingProject(
                new ProjectRequest { ProjectId = "672287966a561cd6cec3b8.03914475" },
                new UploadMarketingFileInput
                {
                    File = new FileReference { Name = "marketing-upload.html", ContentType = "text/html" },
                    LanguageCode = "en"
                });

            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Process.ProcessId));
            Assert.AreEqual("finished", result.Process.Status);
        }

        [TestMethod]
        public async Task UploadFileToMarketingProject_UnsupportedExtension_Throws()
        {
            var action = new FileActions(InvocationContext, FileManager);

            await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(() =>
                action.UploadFileToMarketingProject(
                    new ProjectRequest { ProjectId = "marketing-project" },
                    new UploadMarketingFileInput
                    {
                        File = new FileReference { Name = "marketing-upload.txt" },
                        LanguageCode = "en"
                    }));
        }

        [TestMethod]
        public async Task UploadFileToMarketingProject_TitleOverLimit_Throws()
        {
            var action = new FileActions(InvocationContext, FileManager);

            await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(() =>
                action.UploadFileToMarketingProject(
                    new ProjectRequest { ProjectId = "marketing-project" },
                    new UploadMarketingFileInput
                    {
                        File = new FileReference { Name = "marketing-upload.html" },
                        LanguageCode = "en",
                        Title = new string('a', 257)
                    }));
        }

        [TestMethod]
        public async Task UploadFileToMarketingProject_InvalidUtf8_Throws()
        {
            var fileManager = new Mock<IFileManagementClient>();
            fileManager.Setup(x => x.DownloadAsync(It.IsAny<FileReference>()))
                .ReturnsAsync(new MemoryStream(new byte[] { 0xC3, 0x28 }));
            var action = new FileActions(InvocationContext, fileManager.Object);

            await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(() =>
                action.UploadFileToMarketingProject(
                    new ProjectRequest { ProjectId = "marketing-project" },
                    new UploadMarketingFileInput
                    {
                        File = new FileReference { Name = "marketing-upload.html" },
                        LanguageCode = "en"
                    }));
        }

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

            string jsonResponse = JsonConvert.SerializeObject(glossary, Formatting.Indented);
            Console.WriteLine(jsonResponse);

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
