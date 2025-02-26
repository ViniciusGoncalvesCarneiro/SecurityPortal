using Abp.AspNetCore.Mvc.ViewComponents;

namespace GumAdvisor.Web.Public.Views
{
    public abstract class GumAdvisorViewComponent : AbpViewComponent
    {
        protected GumAdvisorViewComponent()
        {
            LocalizationSourceName = GumAdvisorConsts.LocalizationSourceName;
        }
    }
}