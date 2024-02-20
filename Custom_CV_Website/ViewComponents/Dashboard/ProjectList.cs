using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class ProjectList : ViewComponent
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
    }
}
