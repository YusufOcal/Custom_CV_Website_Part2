using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class VisitorMap : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
