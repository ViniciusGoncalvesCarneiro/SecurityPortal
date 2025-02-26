using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor.Startup
{
    [DependsOn(typeof(GumAdvisorCoreModule))]
    public class GumAdvisorGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}