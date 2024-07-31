using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Category.GetAll;
using NetFilmx_Service.Query.Comment.GetAll;
using NetFilmx_Service.Query.Series.GetAll;
using NetFilmx_Service.Query.Tag.GetAll;
using NetFilmx_Service.Query.User.GetAll;
using NetFilmx_Service.Query.Video.GetAll;
using NetFilmx_Web.Models;
using System.Diagnostics;

namespace NetFilmx_Web.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
