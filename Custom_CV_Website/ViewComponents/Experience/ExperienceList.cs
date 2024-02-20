using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Experince
{
    public class ExperienceList : ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDal());
        public IViewComponentResult Invoke()
        {
            var list = experienceManager.TGetList();
            return View(list);
        }
    }
}
