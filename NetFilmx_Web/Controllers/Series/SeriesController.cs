using Microsoft.AspNetCore.Mvc;

namespace NetFilmx_Web.Controllers.Series
{
    public class SeriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
