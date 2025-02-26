using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
