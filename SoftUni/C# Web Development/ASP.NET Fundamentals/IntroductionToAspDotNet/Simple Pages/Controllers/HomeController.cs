using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Simple_Pages.Models;
using System.Diagnostics;

namespace Simple_Pages.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello World!";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About Page";
            ViewData["Info"] = "This is an ASP.NET Core MVC app.";
            ViewBag.Message = "This is the About page for our first ASP.NET Core MVC app.";

            return View();
        }

        public IActionResult Numbers()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NumbersToN()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NumbersToN(int count = 1)
        {            
            ViewBag.Message = count;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}