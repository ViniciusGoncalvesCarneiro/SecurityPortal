using Abp.Dependency;
using Abp.Reflection.Extensions;
using Microsoft.Extensions.Configuration;
using GumAdvisor.Configuration;

namespace GumAdvisor.Test.Base.Configuration
{
    public class TestAppConfigurationAccessor : IAppConfigurationAccessor, ISingletonDependency
    {
        public IConfigurationRoot Configuration { get; }

        public TestAppConfigurationAccessor()
        {
            Configuration = AppConfigurations.Get(
                typeof(GumAdvisorTestBaseModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }
    }
}
