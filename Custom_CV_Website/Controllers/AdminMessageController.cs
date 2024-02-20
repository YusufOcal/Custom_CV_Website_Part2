using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());
        public IActionResult ReceiverMessageList()
        {
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p = "admin@gmail.com";
            var values = writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult AdminMessageDetails(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }
        public IActionResult AdminMessageDelete(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TRemove(values);

            if (values.Reciever == "admin@gmail.com")
            {
                return RedirectToAction("ReceiverMessageList");
            }
            if (values.Sender == "admin@gmail.com")
            {
                return RedirectToAction("SenderMessageList");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AdminMessageSend()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AdminMessageSend(WriterMessage p)
        {
            p.Sender = "admin@gmail.com";
            p.SenderName = "admin";
            p.Date = DateTime.Now.ToLocalTime();

            Context c = new Context();
            var receiverName = c.Users.Where(x => x.Email == p.Reciever).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            if (receiverName != null)
            {
                p.RecieverName = receiverName;
                writerMessageManager.TAdd(p);
                return RedirectToAction("SenderMessageList");
            }
            else
            {
                ModelState.AddModelError("", "Verileri İstenildiği Şekilde Girin");
            }

            return View();
            
        }
    }
}
