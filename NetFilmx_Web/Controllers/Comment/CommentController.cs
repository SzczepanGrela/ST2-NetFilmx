using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.Comment;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Query.Comment;

namespace NetFilmx_Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;

        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllCommentsQuery<CommentListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Details(int commentId)
        {
            var query = new GetCommentByIdQuery<CommentDetailsDto>(commentId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
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
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CommentAddDto dto)
        {
            var command = new AddCommentCommand(dto.UserId, dto.VideoId, dto.Content);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return RedirectToAction("Index");
        }


    }

}
