using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website.ViewComponents.Dashboard
{
    public class ToDoListPanel : ViewComponent
    {
        ToDoListManager toDoListManager = new ToDoListManager(new EFToDoList());
        public IViewComponentResult Invoke()
        {
            var values = toDoListManager.TGetList();
            return View(values);
        }
    }
}
