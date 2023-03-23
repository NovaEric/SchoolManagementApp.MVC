using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.MVC.Data;

namespace SchoolManagementApp.MVC.Controllers
{
    [Authorize]
    public class SchoolClassesController : Controller
    {
        private readonly SchoolManagementDbContext _context;

        public SchoolClassesController(SchoolManagementDbContext context)
        {
            _context = context;
        }

        // GET: SchoolClasses
        public async Task<IActionResult> Index()
        {
            var schoolManagementDbContext = _context.SchoolClasses.Include(s => s.Course).Include(s => s.Lecture);
            return View(await schoolManagementDbContext.ToListAsync());
        }

        // GET: SchoolClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolClasses == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses
                .Include(s => s.Course)
                .Include(s => s.Lecture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // GET: SchoolClasses/Create
        public IActionResult Create()
        {
            CreateSelectList();
            return View();
        }

        // POST: SchoolClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LectureId,CourseId,Time")] SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CreateSelectList();
            return View(schoolClass);
        }

        // GET: SchoolClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolClasses == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass == null)
            {
                return NotFound();
            }
            CreateSelectList();
            return View(schoolClass);
        }

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LectureId,CourseId,Time")] SchoolClass schoolClass)
        {
            if (id != schoolClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassExists(schoolClass.Id))
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
            CreateSelectList();
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolClasses == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClasses
                .Include(s => s.Course)
                .Include(s => s.Lecture)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolClasses == null)
            {
                return Problem("Entity set 'SchoolManagementDbContext.SchoolClasses'  is null.");
            }
            var schoolClass = await _context.SchoolClasses.FindAsync(id);
            if (schoolClass != null)
            {
                _context.SchoolClasses.Remove(schoolClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassExists(int id)
        {
          return (_context.SchoolClasses?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private void CreateSelectList()
        {
             var courses = _context.Courses.Select(q => new
            {
                CourseDetails = $"{ q.Code } - { q.CourseName } ({ q.Credits } Credits)",
                q.Id
            });
            ViewData["CourseId"] = new SelectList(courses, "Id", "CourseDetails");
            var Lectures = _context.Lecturers.Select(q => new
            {
                FullName = $"{ q.FirstName } { q.LastName }",
                q.Id
            });
            ViewData["LectureId"] = new SelectList(Lectures, "Id", "FullName");

        }
    }
}
