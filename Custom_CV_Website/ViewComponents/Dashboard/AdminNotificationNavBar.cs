using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class AdminNotificationNavBar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
