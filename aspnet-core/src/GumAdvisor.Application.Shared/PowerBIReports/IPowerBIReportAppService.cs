using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.PowerBIReports.Dto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GumAdvisor.PowerBIReports
{
    public interface IPowerBIReportAppService : IApplicationService
    {
        Task<PagedResultDto<GetPowerBIReportForViewDto>> GetAll(GetAllPowerBIReportInput input);
        Task<GetPowerBIReportForViewDto> GetPowerBIReportForView(Guid id);
        Task<GetPowerBIReportForEditOutput> GetPowerBIReportForEdit(EntityDto<Guid> input);
        Task CreateOrEdit(CreateOrEditPowerBIReportDto input);
        Task Delete(EntityDto<Guid> input);

        Task<string> GetAccessToken();
    }
}
