using Abp.Domain.Services;

namespace GumAdvisor
{
    public abstract class GumAdvisorDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected GumAdvisorDomainServiceBase()
        {
            LocalizationSourceName = GumAdvisorConsts.LocalizationSourceName;
        }
    }
}
