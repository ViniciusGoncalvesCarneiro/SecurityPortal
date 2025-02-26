using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    public interface IMitreAppService : IApplicationService
    {
        Task<PagedResultDto<GetMitreForViewDto>> GetAll(GetAllMitreInput input);
    }
}
