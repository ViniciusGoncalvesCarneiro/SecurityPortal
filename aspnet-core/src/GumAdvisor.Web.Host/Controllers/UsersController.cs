using Abp.AspNetCore.Mvc.Authorization;
using GumAdvisor.Authorization;
using GumAdvisor.Storage;
using Abp.BackgroundJobs;

namespace GumAdvisor.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}