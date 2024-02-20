using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")] 
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());

        private readonly UserManager<WriterUser> _userManager;

        public MessageController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [Route("")]
        [Route("ReceiverMessage")]
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;

            var messageList = writerMessageManager.GetListReceiverMessage(p);

            return View(messageList);
        }
        [Route("")]
        [Route("SenderMessage")]
        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;

            var messageList = writerMessageManager.GetListSenderMessage(p);

            return View(messageList);
        }
        [Route("ReceiverMessagesDetails/{id}")]
        public IActionResult ReceiverMessagesDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);

            return View(writerMessage);
        }
        [Route("SenderMessagesDetails/{id}")]
        public IActionResult SenderMessagesDetails(int id)
        {
            WriterMessage writerMessage = writerMessageManager.TGetByID(id);

            return View(writerMessage);
        }
        [HttpGet]
        [Route("")]
        [Route("SendMessage")]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        [Route("")]
        [Route("SendMessage")]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            Context context = new Context(); 

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;

            var namesurname = context.Users.Where(x => x.Email == p.Reciever).Select(y => y.Name + " " + y.Surname).FirstOrDefault();

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            
            if (namesurname != null)
            {
                p.RecieverName = namesurname;
                writerMessageManager.TAdd(p);
                return RedirectToAction("SenderMessage");
            }
            else
            {
                ModelState.AddModelError("", "Verileri İstenildiği Şekilde Girin");
            }

            return View();
        }
    }
}
