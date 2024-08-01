using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Query.Comment;
using NetFilmx_Service.Query.Series;
using NetFilmx_Service.Query.Tag;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Query.Video;
using NetFilmx_Web.Models;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NetFilmx_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        IActionResult Error(string errorMessage, IEnumerable<Error> errors)
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
