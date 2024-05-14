using mdb_project.Model;
using Microsoft.AspNetCore.Mvc;

namespace mdb_project.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmDBContext _context;

        public FilmController(FilmDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
