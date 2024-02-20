using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class Experience2Controller : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListExperience()
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TAdd(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }
        public IActionResult GetById(int ExperienceID)
        {
            var values = JsonConvert.SerializeObject(experienceManager.TGetByID(ExperienceID));
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var bul = experienceManager.TGetByID(id);
            experienceManager.TRemove(bul);
            var values = JsonConvert.SerializeObject(bul);
            return NoContent();
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            var values = JsonConvert.SerializeObject(experience);
            return Json(values);
        }
    }
}
