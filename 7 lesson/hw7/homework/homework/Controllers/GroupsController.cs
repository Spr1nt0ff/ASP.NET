using homework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace homework.Controllers
{
    public class GroupsController : Controller
    {
        private readonly UniversityContext _context;

        public GroupsController(UniversityContext context) {
            _context = context;
        }


        // GET: Groups
        public async Task<IActionResult> Index() {
            return _context.Groups != null ?
                        View(await _context.Groups.ToListAsync()) :
                        Problem("Entity set 'UniversityContext.Groups' is null.");
        }

        // GET: Groups/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Groups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Groups groups) {
            try {
                _context.Add(groups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception) {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id) {
            if (id == null || _context.Groups == null) {
                return NotFound();
            }

            var groups = await _context.Groups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (groups == null) {
                return NotFound();
            }

            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) {
            if (_context.Groups == null) {
                return Problem("Entity set 'UniversityContext.Groups' is null.");
            }
            var groups = await _context.Groups.FindAsync(id);
            if (groups != null) {
                _context.Groups.Remove(groups);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
