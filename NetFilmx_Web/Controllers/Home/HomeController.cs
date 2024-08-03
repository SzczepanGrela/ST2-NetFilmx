using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace NetFilmx_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Error(string errorMessage, List<string> errors = null)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.Errors = errors;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
