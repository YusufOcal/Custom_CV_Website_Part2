using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class WriterUserController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDal());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult WriterList()
        {
            var values = JsonConvert.SerializeObject(writerManager.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterUser writerUser)
        {
            writerManager.TAdd(writerUser);
            var values = JsonConvert.SerializeObject(writerUser);
            return Json(values);
        }
    }
}
