using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDal());
        public IActionResult Index()
        {
            return View(portfolioManager.TGetList());
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if (results.IsValid)
            {
                portfolioManager.TAdd(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
        public IActionResult DeletePortfolio(int id)
        {
            portfolioManager.TRemove(portfolioManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            return View(portfolioManager.TGetByID(id));
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(portfolio);

            if (results.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();
        }
    }
}
