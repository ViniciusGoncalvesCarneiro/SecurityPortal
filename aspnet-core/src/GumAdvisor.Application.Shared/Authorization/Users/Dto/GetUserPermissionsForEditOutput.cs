using System.Collections.Generic;
using GumAdvisor.Authorization.Permissions.Dto;

namespace GumAdvisor.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}