using Abp.AspNetCore.Mvc.Views;

namespace GumAdvisor.Web.Views
{
    public abstract class GumAdvisorRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected GumAdvisorRazorPage()
        {
            LocalizationSourceName = GumAdvisorConsts.LocalizationSourceName;
        }
    }
}
