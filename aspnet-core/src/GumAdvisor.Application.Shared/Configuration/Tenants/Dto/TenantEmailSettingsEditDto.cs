using Abp.Auditing;
using GumAdvisor.Configuration.Dto;

namespace GumAdvisor.Configuration.Tenants.Dto
{
    public class TenantEmailSettingsEditDto : EmailSettingsEditDto
    {
        public bool UseHostDefaultEmailSettings { get; set; }
    }
}