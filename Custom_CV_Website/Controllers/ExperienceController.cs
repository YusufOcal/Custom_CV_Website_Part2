using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IActionResult Index()
        {
            return View(experienceManager.TGetList());
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            experienceManager.TRemove(experienceManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            return View(experienceManager.TGetByID(id));
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
