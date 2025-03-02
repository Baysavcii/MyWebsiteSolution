using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
