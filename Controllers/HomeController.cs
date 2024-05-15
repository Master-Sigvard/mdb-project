using mdb_project.Model;
using Microsoft.AspNetCore.Mvc;

namespace mdb_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmDBContext _context;

        public HomeController(FilmDBContext context)
        {
            _context = context;
        }

        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            var films = _context.Films.ToList();
            return View(films);
        }

        [Route("login")]
        public IActionResult Authorization()
        {
            return View("login");
        }

        [Route("signup")]
        public IActionResult Testing()
        {
            return View("signup");
        }

        [Route("FilmPanel")]
        public IActionResult FilmPanel()
        {
            return View("FilmPanel");
        }
    }
}
