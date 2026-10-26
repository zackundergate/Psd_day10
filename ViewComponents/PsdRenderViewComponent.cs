using Microsoft.AspNetCore.Mvc;
using Psd_day10.Models;

namespace Psd_day10.ViewComponents
{
    public class PsdRenderViewComponent : ViewComponent
    {
        private List<PsdMenuItem> MenuItems = new List<PsdMenuItem>();

        public PsdRenderViewComponent()
        {
            MenuItems = new List<PsdMenuItem>()
            {
                new PsdMenuItem() { Id = 1, Name = "Branches", Link = "/Admin/Student/Branches/List" },
                new PsdMenuItem() { Id = 2, Name = "Students", Link = "/Learner" },
                new PsdMenuItem() { Id = 3, Name = "Subjects", Link = "/Admin/Student/Subjects/List" },
                new PsdMenuItem() { Id = 4, Name = "Courses", Link = "/Admin/Student/Courses/List" }
            };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PsdRenderLeftMenu", MenuItems);
        }
    }
}
