using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    public class GumAdvisorCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorCoreSharedModule).GetAssembly());
        }
    }
}