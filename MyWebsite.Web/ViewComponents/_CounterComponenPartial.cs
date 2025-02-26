using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _CounterComponenPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
