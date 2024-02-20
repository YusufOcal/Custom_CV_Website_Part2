using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Writer")]
    public class ContactSubController : Controller
    {
        ContactManager contactManager = new ContactManager(new EFContactDal());

        [HttpGet]
        public IActionResult Index()
        {
            var mevcutAbout = contactManager.TGetByID(1);
            return View(mevcutAbout);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            contactManager.TUpdate(contact);
            return RedirectToAction("Index", "Default");
        }
    }
}
