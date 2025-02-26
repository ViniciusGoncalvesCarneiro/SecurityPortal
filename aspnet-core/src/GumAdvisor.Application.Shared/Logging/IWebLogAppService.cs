using Abp.Application.Services;
using GumAdvisor.Dto;
using GumAdvisor.Logging.Dto;

namespace GumAdvisor.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
