using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class Last5Projects : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
