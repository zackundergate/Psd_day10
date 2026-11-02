using Microsoft.AspNetCore.Mvc;
using Psd_day10.Data;
using Psd_day10.Models;

namespace Psd_day10.ViewComponents
{
    public class PsdMajorViewComponent : ViewComponent
    {
        PsdSchoolContext db;
        List<PsdMajor> majors;

        public PsdMajorViewComponent(PsdSchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PsdRenderMajor", majors);
        }
    }
}
