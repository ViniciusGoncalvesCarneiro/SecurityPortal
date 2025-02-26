using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace GumAdvisor
{
    [DependsOn(typeof(GumAdvisorClientModule), typeof(AbpAutoMapperModule))]
    public class GumAdvisorXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(GumAdvisorXamarinSharedModule).GetAssembly());
        }
    }
}