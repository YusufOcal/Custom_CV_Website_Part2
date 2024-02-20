using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class AddProjectPanel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}