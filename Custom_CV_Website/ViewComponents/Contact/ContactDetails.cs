using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Contact
{
    public class ContactDetails : ViewComponent
    {
        ContactManager contactManager = new ContactManager(new EFContactDal());
        public IViewComponentResult Invoke()
        {
            var list = contactManager.TGetList();
            return View(list);
        }
    }
}
