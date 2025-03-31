using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homeowork.Models;
using homeowork.Services;
using Microsoft.AspNetCore.Routing;

namespace homeowork.Controllers
{
    public class HomeController : Controller
    {
        private readonly INote _noteManager;

        public HomeController(INote noteManager)
        {
            _noteManager = noteManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Note> notes = await _noteManager.LoadNotes();
            ViewBag.Notes = notes;
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Index(Note note)
        {
            if (!ModelState.IsValid)
                return View(note);

            if (!string.IsNullOrEmpty(note.Tags))
            {
                note.Tags = string.Join(", ", note.Tags.Split(',')
                    .Select(tag => tag.Trim())
                    .Where(tag => !string.IsNullOrEmpty(tag)));
            }

            note.CreatedAt = DateTime.Now;

            await _noteManager.SaveNote(note);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
