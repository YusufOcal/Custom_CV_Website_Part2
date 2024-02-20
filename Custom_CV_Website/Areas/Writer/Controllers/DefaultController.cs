using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        AnnouncementManager _announcementManager = new AnnouncementManager(new EFAnnouncementDal());
        public IActionResult Index()
        {
            var values = _announcementManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement values = _announcementManager.TGetByID(id);

            return View(values);
        }
    } 
}
