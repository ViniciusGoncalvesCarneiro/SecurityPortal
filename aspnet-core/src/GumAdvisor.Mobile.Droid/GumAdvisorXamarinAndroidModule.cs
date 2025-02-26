using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    [DependsOn(typeof(GumAdvisorXamarinSharedModule))]
    public class GumAdvisorXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorXamarinAndroidModule).GetAssembly());
        }
    }
}