using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        public IViewComponentResult Invoke()
        {
            var list = serviceManager.TGetList();
            return View(list);
        }
    }
}
