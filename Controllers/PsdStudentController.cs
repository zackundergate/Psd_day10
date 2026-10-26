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
                Address = "A1-2018", Email = "nam@gmail.com", DateOfBorth = DateTime.Parse("2000-01-01"), Score = 8.5 },
            new PsdStudent() { Id = 102, Name = "Minh Tú", Branch = PsdBranch.BE,
                Gender = PsdGender.Female, IsRegular = true,
                Address = "A1-2019", Email = "tu@gmail.com", DateOfBorth = DateTime.Parse("2001-02-15"), Score = 7.0 },
            new PsdStudent() { Id = 103, Name = "Hoàng Phong", Branch = PsdBranch.CE,
                Gender = PsdGender.Male, IsRegular = false,
                Address = "A1-2020", Email = "phong@gmail.com", DateOfBorth = DateTime.Parse("1999-11-20"), Score = 6.5 },
            new PsdStudent() { Id = 104, Name = "Xuân Mai", Branch = PsdBranch.EE,
                Gender = PsdGender.Female, IsRegular = false,
                Address = "A1-2021", Email = "mai@gmail.com", DateOfBorth = DateTime.Parse("2002-08-10"), Score = 9.0 }
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
            if (ModelState.IsValid)
            {
                s.Id = listStudents.Last().Id + 1;
                listStudents.Add(s);
                return View("PsdIndex", listStudents);
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(PsdGender)).Cast<PsdGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View("PsdCreate", s);
        }

        [HttpGet]
        [Route("Admin/Student/Edit/{id?}")]
        [Route("Admin/PsdStudent/Edit/{id?}")]
        [Route("Student/Edit/{id?}")]
        [Route("PsdStudent/Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(PsdGender)).Cast<PsdGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View("PsdEdit", student);
        }

        [HttpPost]
        [Route("Admin/Student/Edit/{id?}")]
        [Route("Admin/PsdStudent/Edit/{id?}")]
        [Route("Student/Edit/{id?}")]
        [Route("PsdStudent/Edit/{id?}")]
        public IActionResult Edit(int id, PsdStudent s)
        {
            if (ModelState.IsValid)
            {
                var index = listStudents.FindIndex(x => x.Id == id);
                if (index != -1)
                {
                    s.Id = id;
                    listStudents[index] = s;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AllGenders = Enum.GetValues(typeof(PsdGender)).Cast<PsdGender>().ToList();
            ViewBag.AllBranches = new List<SelectListItem>()
            {
                new SelectListItem { Text = "IT", Value = "1" },
                new SelectListItem { Text = "BE", Value = "2" },
                new SelectListItem { Text = "CE", Value = "3" },
                new SelectListItem { Text = "EE", Value = "4" }
            };
            return View("PsdEdit", s);
        }

        [HttpGet]
        [Route("Admin/Student/Delete/{id?}")]
        [Route("Admin/PsdStudent/Delete/{id?}")]
        [Route("Student/Delete/{id?}")]
        [Route("PsdStudent/Delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View("PsdDelete", student);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Student/Delete/{id?}")]
        [Route("Admin/PsdStudent/Delete/{id?}")]
        [Route("Student/Delete/{id?}")]
        [Route("PsdStudent/Delete/{id?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = listStudents.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                listStudents.Remove(student);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
