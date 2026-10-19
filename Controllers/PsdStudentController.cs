using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Psd_day10.Models;

namespace Psd_day10.Controllers
{
    public class PsdStudentController : Controller
    {
        private static List<PsdStudent> listStudents = new List<PsdStudent>()
        {
            new PsdStudent() { Id = 101, Name = "Hải Nam", Branch = PsdBranch.IT,
                Gender = PsdGender.Male, IsRegular = true,
                Address = "A1-2018", Email = "nam@g.com" },
            new PsdStudent() { Id = 102, Name = "Minh Tú", Branch = PsdBranch.BE,
                Gender = PsdGender.Female, IsRegular = true,
                Address = "A1-2019", Email = "tu@g.com" },
            new PsdStudent() { Id = 103, Name = "Hoàng Phong", Branch = PsdBranch.CE,
                Gender = PsdGender.Male, IsRegular = false,
                Address = "A1-2020", Email = "phong@g.com" },
            new PsdStudent() { Id = 104, Name = "Xuân Mai", Branch = PsdBranch.EE,
                Gender = PsdGender.Female, IsRegular = false,
                Address = "A1-2021", Email = "mai@g.com" }
        };

        [Route("Admin/Student/List")]
        [Route("Admin/PsdStudent/List")]
        [Route("Student/Index")]
        [Route("PsdStudent/Index")]
        [Route("PsdStudent")]
        [Route("Student")]
        [Route("Students/List")]
        [Route("Admin/Student/Students/List")]
        [Route("Admin/Student/Branches/List")]
        [Route("Admin/Student/Subjects/List")]
        [Route("Admin/Student/Courses/List")]
        [Route("Admin/Student/index.html")]
        [Route("Branches/List")]
        [Route("Subjects/List")]
        [Route("Courses/List")]
        [Route("index.html")]
        public IActionResult Index()
        {
            return View("PsdIndex", listStudents);
        }

        [HttpGet]
        [Route("Admin/Student/Add")]
        [Route("Admin/PsdStudent/Add")]
        [Route("Student/Create")]
        [Route("PsdStudent/Create")]
        public IActionResult Create()
        {
            ViewBag.AllGenders = Enum.GetValues(typeof(PsdGender)).Cast<PsdGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View("PsdCreate");
        }

        [HttpPost]
        [Route("Admin/Student/Add")]
        [Route("Admin/PsdStudent/Add")]
        [Route("Student/Create")]
        [Route("PsdStudent/Create")]
        public IActionResult Create(PsdStudent s)
        {
            s.Id = listStudents.Last().Id + 1;
            listStudents.Add(s);
            return View("PsdIndex", listStudents);
        }
    }
}
