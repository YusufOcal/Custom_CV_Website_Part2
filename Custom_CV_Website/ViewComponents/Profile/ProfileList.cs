using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Profile
{
    public class ProfileList : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.img = values.ImageUrl;
            ViewBag.name = values.Name + " " + values.Surname;
            return View();
        }
    }
}

