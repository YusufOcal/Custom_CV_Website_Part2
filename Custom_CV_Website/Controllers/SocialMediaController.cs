using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Writer")]
    public class SocialMediaController : Controller
    {
        SocialManager socialManager = new SocialManager(new EFSocialDal());
        public IActionResult Index()
        {
            var values = socialManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteSocial(int id)
        {
            var value = socialManager.TGetByID(id);
            socialManager.TRemove(value);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddSocial() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocial(Social social)
        {
            socialManager.TAdd(social);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSocial(int id)
        {
            var value = socialManager.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult EditSocial(Social social)
        {
            socialManager.TUpdate(social);
            return RedirectToAction("Index");
        }
    }
}
