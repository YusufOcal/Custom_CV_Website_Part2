using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        SkillManager skillManager = new SkillManager(new EFSkillDal());
        public IViewComponentResult Invoke()
        {
            var list = skillManager.TGetList();
            return View(list);
        }
    }
}
