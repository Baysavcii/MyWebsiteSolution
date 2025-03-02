using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
