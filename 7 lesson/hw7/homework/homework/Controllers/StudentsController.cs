using homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace homework.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UniversityContext _context;

        public StudentsController(UniversityContext context) {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index() {
            var soccerContext = _context.Students.Include(p => p.Group);
            return View(await soccerContext.ToListAsync());
        }

        // GET: Students/Create
        public IActionResult Create() {
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, FirstName, LastName, Age, GroupId")] Students students) {
            try {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) {
                return RedirectToAction(nameof(Index));
            }
        }


        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Students == null) {
                return NotFound();
            }

            var students = await _context.Students
                .Include(p => p.Group)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null) {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Students == null) {
                return Problem("Entity set 'UniversityContext.Students'  is null.");
            }
            var students = await _context.Students.FindAsync(id);
            if (students != null) {
                _context.Students.Remove(students);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
