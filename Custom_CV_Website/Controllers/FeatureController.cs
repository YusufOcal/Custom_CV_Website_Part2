using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Writer")]
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());

        [HttpGet]
        public IActionResult Index()
        {
            var mevcutFeature = featureManager.TGetByID(1);
            return View(mevcutFeature);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            featureManager.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }

    }
}
