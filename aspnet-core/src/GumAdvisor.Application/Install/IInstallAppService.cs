using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.Install.Dto;

namespace GumAdvisor.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}