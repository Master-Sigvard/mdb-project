using mdb_project.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace mdb_project.Controllers
{
    public class UsersController : Controller
    {
        private readonly FilmDBContext _context;

        private bool CheckUserCreation(User user)
        {
            bool errors = false;

            string error = "Error, enter your";

            if (user.Name.IsNullOrEmpty())
            {
                error += " name,";
                errors = true;
            }

            if (user.Email.IsNullOrEmpty())
            {
                error += " email,";
                errors = true;
            }

            if (user.Password.IsNullOrEmpty())
            {
                error += " password.";
                errors = true;
            }

            char[] chars = error.ToCharArray();
            chars[chars.Length - 1] = '.';
            error = new string(chars);

            var emails = _context.Users.Select(u => u.Email).ToList();

            if (emails.Contains(user.Email))
            {
                error = "entered email is already used.";
                errors = true;
            }

            ViewBag.ErrorMessage = error;
            return errors;
        }

        private bool CheckUserLogin(User user)
        {
            bool errors = false;
            string error = "Error, enter your";

            if (user.Email.IsNullOrEmpty())
            {
                error += " email,";
                errors = true;
            }

            if (user.Password.IsNullOrEmpty())
            {
                error += " password.";
                errors = true;
            }

            char[] chars = error.ToCharArray();
            chars[chars.Length - 1] = '.';
            error = new string(chars);

            if (errors) ViewBag.ErrorMessage = error;
            return errors;
        }

        private bool IsValidUser(string email, string password)
        {
            var emails = _context.Users.Select(u => u.Email).ToList();
            var passwords = _context.Users.Select(u => u.Password).ToList();

            if (emails.Contains(email) && passwords.Contains(password)) return true;
            ViewBag.ErrorMessage = "invalid email or password";
            return false;
        }

        public UsersController(FilmDBContext context)
        {
            _context = context;
        }

        [Route("signup/created")]
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (CheckUserCreation(user)) return View("SignUp");

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");  
            }
            return View("SignUp");
        }

        [Route("signup/deleted")]
        [HttpPost]
        public IActionResult DeleteAll(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.ExecuteDelete();
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View("login");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (CheckUserLogin(user)) return View("Login");

            if (IsValidUser(user.Email, user.Password))
            {
                var currentUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                var name = currentUser.Name;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, name),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            }
            return View("Index");
        }

        [Route("Logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Index");
        }
    }
}
