using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using GumAdvisor.Authorization;

namespace GumAdvisor
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(GumAdvisorApplicationSharedModule),
        typeof(GumAdvisorCoreModule)
        )]
    public class GumAdvisorApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorApplicationModule).GetAssembly());
        }
    }
}