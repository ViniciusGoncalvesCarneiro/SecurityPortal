using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.Configuration.Tenants.Dto;

namespace GumAdvisor.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
