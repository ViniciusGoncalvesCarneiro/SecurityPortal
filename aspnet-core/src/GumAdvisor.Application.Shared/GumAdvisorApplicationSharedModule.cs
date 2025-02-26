using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    [DependsOn(typeof(GumAdvisorCoreSharedModule))]
    public class GumAdvisorApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorApplicationSharedModule).GetAssembly());
        }
    }
}