using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    public interface ICisToIsoAppService : IApplicationService
    {
        Task<PagedResultDto<GetCisToIsoForViewDto>> GetAll(GetAllCisToIsotInput input);
    }
}
