using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    public class GumAdvisorClientModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorClientModule).GetAssembly());
        }
    }
}
