using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.Common.Dto;
using GumAdvisor.Editions.Dto;

namespace GumAdvisor.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}