using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        private readonly UserManager<WriterUser> _userManager;

        public SlideList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var list = portfolioManager.TGetList();
            var bul = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.img = bul.ImageUrl;
            return View(list);
        }
    }
}

