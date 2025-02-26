using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.Configuration.Host.Dto;

namespace GumAdvisor.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
