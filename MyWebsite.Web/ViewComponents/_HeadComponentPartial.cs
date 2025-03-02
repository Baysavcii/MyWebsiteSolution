using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _HeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
