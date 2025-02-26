using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    [DependsOn(typeof(GumAdvisorXamarinSharedModule))]
    public class GumAdvisorXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorXamarinIosModule).GetAssembly());
        }
    }
}