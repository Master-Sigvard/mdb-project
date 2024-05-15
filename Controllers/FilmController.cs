using mdb_project.Migrations;
using mdb_project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace mdb_project.Controllers
{
    public class FilmController : Controller
    {
        private readonly FilmDBContext _context;

        public FilmController(FilmDBContext context)
        {
            _context = context;
        }

        [Route("FilmPanel/created")]
        [HttpPost]
        public IActionResult Create(Film film)
        {
            if (ModelState.IsValid)
            {
                //if (CheckUserCreation(user)) return View("SignUp");

                _context.Films.Add(film);
                _context.SaveChanges();
            }
            ViewBag.Message = "Film created";
            return View("FilmPanel");
        }

        [Route("/FilmView")]
        public IActionResult FilmView(int id)
        {
            var film = _context.Films.FirstOrDefault(f => f.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            var reviews = _context.Reviews.Where(r => r.FilmId == id).ToList();

            var usersWhoReviewedFilmId = _context.Reviews
                .Where(r => r.FilmId == id)
                .Select(r => r.UserId)
                .Distinct()
                .ToList();

            var users = _context.Users
                .Where(u => usersWhoReviewedFilmId.Contains(u.Id))
                .ToList();

            var viewModel = new FilmViewModel
            {
                Film = film,
                Reviews = reviews,
                Users = users
            };

            return View(viewModel);
        }

        [Route("search")]
        [HttpPost]
        public IActionResult FilmSearch(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.SearchString = searchString;

            var movies = _context.Films
                .Where(f => f.Name.Contains(searchString))
                .ToList();

            return View("FilmSearch", movies);
        }

        [Route("FilmView/ReviewCreated")]
        [HttpPost]
        public IActionResult CreateReview(Review review)
        {
            if (ModelState.IsValid)
            {
                var existingReview = _context.Reviews.FirstOrDefault(r => 
                r.UserId == review.UserId && r.FilmId == review.FilmId);

                if (existingReview != null)
                {
                    // Updating existing review
                    existingReview.Rating = review.Rating;
                    existingReview.Text = review.Text;

                    _context.SaveChanges();

                    return RedirectToAction("FilmView", new { id = review.FilmId });
                }

                _context.Reviews.Add(review);
                _context.SaveChanges();
            }
            return RedirectToAction("FilmView", new {id = review.FilmId});
        }

    }
}
