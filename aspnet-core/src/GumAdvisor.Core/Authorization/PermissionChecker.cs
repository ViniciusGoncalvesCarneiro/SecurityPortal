using Abp.Authorization;
using GumAdvisor.Authorization.Roles;
using GumAdvisor.Authorization.Users;

namespace GumAdvisor.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
