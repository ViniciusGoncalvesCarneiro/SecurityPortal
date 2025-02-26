using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace GumAdvisor.Web.Public.Views
{
    public abstract class GumAdvisorRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected GumAdvisorRazorPage()
        {
            LocalizationSourceName = GumAdvisorConsts.LocalizationSourceName;
        }
    }
}
