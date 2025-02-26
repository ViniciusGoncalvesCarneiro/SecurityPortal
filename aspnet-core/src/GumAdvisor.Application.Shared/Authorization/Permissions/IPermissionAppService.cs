using Abp.Application.Services;
using Abp.Application.Services.Dto;
using GumAdvisor.Authorization.Permissions.Dto;

namespace GumAdvisor.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
