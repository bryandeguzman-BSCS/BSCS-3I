using Microsoft.AspNetCore.Mvc;
using System_student_record.Models;

namespace System_student_record.Controllers
{
    public class AccountController : Controller
    {
        static List<User> users =
        new List<User>()
        {
            new User
            {
                Id = 1,
                FullName = "Admin",
                Username = "admin",
                Password = "admin123"
            }
        };

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login
        (
            string username,
            string password
        )
        {
            var user =
            users.FirstOrDefault(x =>
            x.Username == username &&
            x.Password == password);

            if (user != null)
            {
                HttpContext.Session
                .SetString("User", username);

                return RedirectToAction
                (
                    "Dashboard",
                    "Students"
                );
            }

            ViewBag.Error =
            "Invalid Username or Password";

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            user.Id = users.Count + 1;

            users.Add(user);

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }
    }
}