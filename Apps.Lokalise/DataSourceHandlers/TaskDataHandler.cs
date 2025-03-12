using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Requests.Tasks;
using Apps.Lokalise.Models.Responses.Tasks;
using Apps.Lokalise.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Lokalise.DataSourceHandlers;

public class TaskDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    private readonly string _projectId;

    public TaskDataHandler(InvocationContext invocationContext, [ActionParameter] GetTaskRequest taskRequest) : base(
        invocationContext)
    {
        _projectId = taskRequest.ProjectId;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(_projectId))
            throw new PluginMisconfigurationException("You should input a project ID first");

        string endpoint = $"/projects/{_projectId}/tasks";
        var tasks = await Paginator.GetAll<TasksWrapper, TaskResponse>(Creds, endpoint);


        return tasks.Where(x => context.SearchString == null ||
                                x.Title.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .DistinctBy(x => x.TaskId)
            .OrderByDescending(x => x.CreatedAt)
            .Take(20)
            .ToDictionary(x => x.TaskId, x => x.Title);
    }
}