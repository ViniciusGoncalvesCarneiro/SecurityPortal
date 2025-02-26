using Microsoft.AspNetCore.Mvc;
using GumAdvisor.Web.Controllers;

namespace GumAdvisor.Web.Public.Controllers
{
    public class HomeController : GumAdvisorControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}