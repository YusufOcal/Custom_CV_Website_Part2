using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IActionResult Index()
        {
            var list = skillManager.TGetList();
            return View(list);
        }
        [HttpGet]
        public IActionResult AddSkill() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            skillManager.TRemove(skillManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id) 
        {
            var mevcutSkills = skillManager.TGetByID(id);
            return View(mevcutSkills);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
