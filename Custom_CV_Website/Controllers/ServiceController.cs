using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Writer")]
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        public IActionResult Index()
        {
            var mevcutService = serviceManager.TGetList();
            return View(mevcutService);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            serviceManager.TRemove(serviceManager.TGetByID(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            var mevcutServices = serviceManager.TGetByID(id);
            return View(mevcutServices);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
