using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _ProjectsComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
