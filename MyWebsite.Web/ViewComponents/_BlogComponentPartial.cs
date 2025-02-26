using Microsoft.AspNetCore.Mvc;

namespace MyWebsite.Web.ViewComponents
{
    public class _BlogComponentPartial:ViewComponent
    {   
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
