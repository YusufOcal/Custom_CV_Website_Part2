using Custom_CV_Website.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace Custom_CV_Website.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);

            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if(model.Picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(model.Picture.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userimage/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await model.Picture.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }

            user.Name = model.Name;
            user.Surname = model.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
