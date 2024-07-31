using Microsoft.AspNetCore.Mvc;

namespace NetFilmx_Web.Controllers.Comment
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
