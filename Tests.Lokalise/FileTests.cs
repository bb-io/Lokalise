﻿using Apps.Lokalise.Actions;
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
        public async Task DownloadProjectFiles_IsSuccess()
        {
            var action = new FileActions(InvocationContext, FileManager);
            var glossary = await action.DownloadProjectFilesAsZip(new ProjectRequest { ProjectId = "43255416680bccef893775.42965789" }, 
                new DownloadFileRequest {Format= "json" });
            Assert.IsNotNull(glossary);
        }
    }
}
