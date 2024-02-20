using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Custom_CV_Website.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        FeatureManager featureManager = new FeatureManager(new EFFeatureDal());
        public IViewComponentResult Invoke()
        {
            var list = featureManager.TGetList();

            return View(list);
        }
    }
}
