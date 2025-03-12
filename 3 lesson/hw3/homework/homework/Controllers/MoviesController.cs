using Microsoft.AspNetCore.Mvc;

namespace MoviesMVC
{
    public class MoviesController : Controller
    {
        MoviesContext db;

        public MoviesController(MoviesContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Movies> movies = await Task.Run(() => db.Movies);
            ViewBag.Movies = movies;
            return View();
        }
    }
}

