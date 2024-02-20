using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Testimonial
{
    public class TestimonialList : ViewComponent
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDal());
        public IViewComponentResult Invoke()
        {
            var list = testimonialManager.TGetList();
            return View(list);
        }
    }
}
