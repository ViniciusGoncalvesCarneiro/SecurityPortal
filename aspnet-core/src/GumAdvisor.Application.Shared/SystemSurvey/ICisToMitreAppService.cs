using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    public interface ICisToMitreAppService : IApplicationService
    {
        Task<PagedResultDto<GetCisToMitreForViewDto>> GetAll(GetAllCisToMitreInput input);
    }
}
