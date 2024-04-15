using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Lokalise;

public class LokaliseApplication : IApplication
{
    public string Name
    {
        get => "Lokalise";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}