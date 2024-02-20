using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Portfolio
{
    public class PortfolioList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var list = portfolioManager.TGetList();
            return View(list);
        }
    }
}
