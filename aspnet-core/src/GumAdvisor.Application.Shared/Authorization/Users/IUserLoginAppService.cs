using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.Authorization.Users.Dto;

namespace GumAdvisor.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<PagedResultDto<UserLoginAttemptDto>> GetUserLoginAttempts(GetLoginAttemptsInput input);
    }
}
