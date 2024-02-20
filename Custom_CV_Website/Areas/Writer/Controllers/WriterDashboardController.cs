using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Xml.Linq;

namespace Custom_CV_Website.Areas.Writer.Controllers
{
    [Area("Writer")]
    public class WriterDashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        public WriterDashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //Weather Api
            string api = "d94a7df4bcf77feea7d7cc620a08f6e2";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=Kayseri&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument xDocument = XDocument.Load(connection);
            ViewBag.temp = xDocument.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //statistics
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name + " " + values.Surname;

            Context context = new Context();
            ViewBag.v1 = context.WriterMessages.Where(x => x.Reciever == values.Email).Count();
            ViewBag.v2 = context.Announcements.Count();
            ViewBag.v3 = context.Users.Count();
            //ViewBag.v4 = context.Skills.Count(); toplam yetenek sayısını veriyor
            ViewBag.v4 = context.WriterMessages.Where(x => x.Sender == values.Email).Count();

            return View();
        }
    }
}
