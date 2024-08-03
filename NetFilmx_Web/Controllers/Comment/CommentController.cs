using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Comment;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Query.Video;

namespace NetFilmx_Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        private async Task<List<UserListDto>> GetUsers()
        {
            var query = new GetAllUsersQuery<UserListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return new List<UserListDto>();
            }

            return result.Data;

        }



        private async Task<List<VideoListDto>> GetVideos()
        {
            var query = new GetAllVideosQuery<VideoListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return new List<VideoListDto>();
            }

            return result.Data;

        }



        public async Task<IActionResult> Index()
        {
            var query = new GetAllCommentsQuery<CommentListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Details(int commentId)
        {
            var query = new GetCommentByIdQuery<CommentDetailsDto>(commentId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            var command = new DeleteCommentCommand(commentId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }


        public IActionResult Add()
        {
            ViewBag.Users = new SelectList(GetUsers().Result, "Id", "Username");
            ViewBag.Videos = new SelectList(GetVideos().Result, "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto dto)
        {
            var command = new AddCommentCommand(dto.UserId, dto.VideoId, dto.Content);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }


    }

}
