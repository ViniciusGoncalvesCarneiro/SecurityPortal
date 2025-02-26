using Microsoft.AspNetCore.Antiforgery;

namespace GumAdvisor.Web.Controllers
{
    public class AntiForgeryController : GumAdvisorControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
