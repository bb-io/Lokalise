using Apps.Lokalise.Actions;
using Apps.Lokalise.Models.Requests.Tasks;
using Blackbird.Applications.Sdk.Common.Exceptions;
using LokaliseTests.Base;

namespace Tests.Lokalise;

[TestClass]
public class TaskTests : TestBase
{
    private const string ProjectId = "179791676a6757a1445a28.59628328";

    [TestMethod]
    public async Task GetFilesFromTask_OneFileTask_ReturnsUniqueFileName()
    {
        var action = new TaskActions(InvocationContext);
        var result = await action.GetFilesFromTask(new GetTaskRequest
        {
            ProjectId = ProjectId,
            TaskId = "3796445"
        });

        Console.WriteLine(string.Join(", ", result.FileNames));
        CollectionAssert.AreEqual(new[] { "27.html" }, result.FileNames);
    }

    [TestMethod]
    public async Task GetFilesFromTask_TwoFileTask_ReturnsSortedFileNames()
    {
        var action = new TaskActions(InvocationContext);
        var result = await action.GetFilesFromTask(new GetTaskRequest
        {
            ProjectId = ProjectId,
            TaskId = "3796446"
        });

        Console.WriteLine(string.Join(", ", result.FileNames));
        CollectionAssert.AreEqual(new[] { "23.html", "26.html" }, result.FileNames);
    }

    [TestMethod]
    public async Task GetFilesFromTask_EmptyProjectId_ThrowsMisconfigurationError()
    {
        var action = new TaskActions(InvocationContext);

        await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(() =>
            action.GetFilesFromTask(new GetTaskRequest
            {
                ProjectId = string.Empty,
                TaskId = "3796445"
            }));
    }

    [TestMethod]
    public async Task GetFilesFromTask_EmptyTaskId_ThrowsMisconfigurationError()
    {
        var action = new TaskActions(InvocationContext);

        await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(() =>
            action.GetFilesFromTask(new GetTaskRequest
            {
                ProjectId = ProjectId,
                TaskId = string.Empty
            }));
    }
}
