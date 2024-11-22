using Microsoft.AspNetCore.Mvc;
using CMCS.Models;

namespace CMCS.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            if (ValidateUser(username, password))
            {
                // Set session variables
                HttpContext.Session.SetString("Role", "Admin"); 
                HttpContext.Session.SetInt32("UserId", 1); 
                return RedirectToAction("Dashboard", "Home");
            }

            ModelState.AddModelError("", "Invalid username or password");
            return View();
        }

        private bool ValidateUser(string username, string password)
        {
            return username == "admin" && password == "password";
        }

        public IActionResult Login()
        {
            return View();
        }
    }


}
