using System.Threading.Tasks;
using Abp.Application.Services;
using GumAdvisor.Sessions.Dto;

namespace GumAdvisor.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
