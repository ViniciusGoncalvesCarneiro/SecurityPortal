using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    public interface IIsoAppService : IApplicationService
    {
        Task<PagedResultDto<GetIsoForViewDto>> GetAll(GetAllIsoInput input);
    }
}
