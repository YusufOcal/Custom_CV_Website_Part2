using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDal());
        Context context = new Context();

        private readonly UserManager<WriterUser> _userManager;

        public MessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = messageManager.TGetList().Take(5).ToList();
            var bul = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.img = bul.ImageUrl;
            return View(values);
        }
    }
}