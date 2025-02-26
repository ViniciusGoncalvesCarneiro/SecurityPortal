using Microsoft.AspNetCore.Mvc;
using GumAdvisor.Web.Controllers;

namespace GumAdvisor.Web.Public.Controllers
{
    public class AboutController : GumAdvisorControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}