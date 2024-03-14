using Microsoft.AspNetCore.Mvc;

namespace mdb_project.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("home")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [Route("login")]
        public IActionResult Authorization()
        {
            return View("login");
        }
    }
}
