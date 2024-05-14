using Microsoft.AspNetCore.Mvc;

namespace mdb_project.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            Console.WriteLine("homepage");
            return View("Index");
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
