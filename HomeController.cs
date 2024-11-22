using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
