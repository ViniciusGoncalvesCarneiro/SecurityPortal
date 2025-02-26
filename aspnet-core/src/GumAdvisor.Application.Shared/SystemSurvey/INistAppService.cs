using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    public interface INistAppService : IApplicationService
    {
        Task<PagedResultDto<GetNistForViewDto>> GetAll(GetAllNistInput input);
    }
}
