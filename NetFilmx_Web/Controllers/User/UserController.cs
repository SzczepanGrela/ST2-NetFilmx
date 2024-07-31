using Microsoft.AspNetCore.Mvc;

namespace NetFilmx_Web.Controllers.User
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
