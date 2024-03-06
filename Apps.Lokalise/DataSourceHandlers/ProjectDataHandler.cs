using Apps.Lokalise.Invocables;
using Apps.Lokalise.Models.Responses.Projects;
using Apps.Lokalise.RestSharp;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Lokalise.DataSourceHandlers;

public class ProjectDataHandler : LokaliseInvocable, IAsyncDataSourceHandler
{
    public ProjectDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(
        DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var request = new LokaliseRequest("/projects", Method.Get, Creds);
        var projects = await Client.ExecuteWithHandling<ProjectsResponse>(request);

        return projects.Projects
            .Where(x => context.SearchString == null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .DistinctBy(x => x.ProjectId)
            .OrderByDescending(x => x.CreatedAt)
            .DistinctBy(x => x.ProjectId)
            .Take(20)
            .ToDictionary(x => x.ProjectId, x => x.Name);
    }
}