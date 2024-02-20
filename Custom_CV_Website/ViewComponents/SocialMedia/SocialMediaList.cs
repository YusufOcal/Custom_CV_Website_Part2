using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.SocialMedia
{
    public class SocialMediaList : ViewComponent
    {
        SocialManager socialManager = new SocialManager(new EFSocialDal());
        public IViewComponentResult Invoke()
        {
            var values = socialManager.TGetList();
            return View(values);
        }
    }
}
