using Microsoft.AspNetCore.Mvc;

namespace NetFilmx_Web.Controllers.Video
{
    public class VideoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
