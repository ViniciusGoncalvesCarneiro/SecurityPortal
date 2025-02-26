using Microsoft.Extensions.Configuration;

namespace GumAdvisor.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
