using Abp.Application.Services.Dto;
using GumAdvisor.SystemSurvey.Dto;
using System;
using System.Threading.Tasks;

namespace GumAdvisor.SystemSurvey
{
    //[AbpAuthorize(AppPermissions.Pages_Addresses)]
    public class CisToIsoAppService : GumAdvisorAppServiceBase, ICisToIsoAppService
    {
        public Task<PagedResultDto<GetCisToIsoForViewDto>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
