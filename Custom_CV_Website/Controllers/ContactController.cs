using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Writer")]
    public class ContactController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        public IActionResult Index()
        {
            var values = messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = messageManager.TGetByID(id);
            messageManager.TRemove(values);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id) 
        {
            var values = messageManager.TGetByID(id);
            return View(values);
        }
    }
}
