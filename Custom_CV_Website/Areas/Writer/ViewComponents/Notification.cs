using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Areas.Writer.ViewComponents
{
    public class Notification : ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDal());
        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList().Take(4).ToList();
            return View(values);
        }
    }
}
