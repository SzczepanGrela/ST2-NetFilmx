using Microsoft.AspNetCore.Mvc;
using NetFilmx_Web.Models;
using System.Diagnostics;

namespace NetFilmx_Web.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Videos()
        {
            return View();
        }

        public IActionResult Categories()
        {
            return View();
        }
        public IActionResult Comments()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Series()
        {
            return View();
        }
        public IActionResult Tags()
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
