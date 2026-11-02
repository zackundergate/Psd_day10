using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Psd_day10.Data;
using Psd_day10.Models;

namespace Psd_day10.Controllers
{
    public class PsdLearnerController : Controller
    {
        private PsdSchoolContext db;
        private int pageSize = 3;

        public PsdLearnerController(PsdSchoolContext context)
        {
            db = context;
        }

        [Route("Learner/Index")]
        [Route("Learner")]
        [Route("PsdLearner/Index")]
        [Route("PsdLearner")]
        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<PsdLearner>)db.Learners.Include(m => m.Major);
            if (mid != null)
            {
                learners = (IQueryable<PsdLearner>)db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major);
                ViewBag.mid = mid;
            }
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = learners.Take(pageSize).ToList();
            return View("PsdIndex", result);
        }

        [Route("Learner/LearnerByMajorID")]
        [Route("PsdLearner/LearnerByMajorID")]
        [Route("LearnerByMajorID")]
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();
            return PartialView("PsdLearnerTable", learners);
        }

        [Route("Learner/LearnerFilter")]
        [Route("PsdLearner/LearnerFilter")]
        [Route("LearnerFilter")]
        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            var learners = (IQueryable<PsdLearner>)db.Learners;
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                ViewBag.mid = mid;
            }
            if (keyword != null)
            {
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(keyword.ToLower()));
                ViewBag.keyword = keyword;
            }
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            var result = learners.Skip(pageSize * (page - 1)).Take(pageSize).Include(m => m.Major).ToList();
            return PartialView("PsdLearnerTable", result);
        }

        [HttpGet]
        [Route("Learner/Create")]
        [Route("PsdLearner/Create")]
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View("PsdCreate");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Learner/Create")]
        [Route("PsdLearner/Create")]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] PsdLearner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View("PsdCreate", learner);
        }

        [HttpGet]
        [Route("Learner/Edit/{id?}")]
        [Route("PsdLearner/Edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View("PsdEdit", learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Learner/Edit/{id?}")]
        [Route("PsdLearner/Edit/{id?}")]
        public IActionResult Edit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] PsdLearner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View("PsdEdit", learner);
        }

        [HttpGet]
        [Route("Learner/Delete/{id?}")]
        [Route("PsdLearner/Delete/{id?}")]
        public IActionResult Delete(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);
            if (learner == null)
            {
                return NotFound();
            }
            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }
            return View("PsdDelete", learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Learner/Delete/{id?}")]
        [Route("PsdLearner/Delete/{id?}")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }
            var learner = db.Learners.Find(id);
            if (learner != null)
            {
                db.Learners.Remove(learner);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }
    }
}
