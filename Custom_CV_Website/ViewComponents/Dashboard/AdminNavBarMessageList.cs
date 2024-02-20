using BusinessLayer.Concrete;
using Custom_CV_Website.ViewComponents.Profile;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class AdminNavBarMessageList : ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDal());
        Context context = new Context();

        private readonly UserManager<WriterUser> _userManager;

        public AdminNavBarMessageList(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var admin = await _userManager.FindByNameAsync(User.Identity.Name);
            string p = admin.Email;
            ViewBag.count = context.WriterMessages.Where(x => x.Reciever == p).Count();

            var values = writerMessageManager.GetListReceiverMessage(p).OrderBy(x => x.ID).Take(3).ToList();

            var tut = context.WriterMessages.Where(x => x.Reciever == p).Select(y => y.Sender).FirstOrDefault();

            var valuess = await _userManager.FindByEmailAsync(tut);
            ViewBag.img = valuess.ImageUrl;

            return View(values);
        }
    }
}
