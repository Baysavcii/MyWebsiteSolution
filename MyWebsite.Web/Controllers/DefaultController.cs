using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
