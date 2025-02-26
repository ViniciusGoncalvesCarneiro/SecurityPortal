using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.Editions.Dto;
using GumAdvisor.MultiTenancy.Dto;

namespace GumAdvisor.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}