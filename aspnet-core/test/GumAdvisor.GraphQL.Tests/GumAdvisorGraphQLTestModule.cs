using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using GumAdvisor.Configure;
using GumAdvisor.Startup;
using GumAdvisor.Test.Base;

namespace GumAdvisor.GraphQL.Tests
{
    [DependsOn(
        typeof(GumAdvisorGraphQLModule),
        typeof(GumAdvisorTestBaseModule))]
    public class GumAdvisorGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorGraphQLTestModule).GetAssembly());
        }
    }
}