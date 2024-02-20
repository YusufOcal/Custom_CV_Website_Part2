using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.About
{
    public class AboutList : ViewComponent
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDal());
        public IViewComponentResult Invoke()
        {
            var list = aboutManager.TGetList();
            return View(list);
        }
    }
}
