using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.User;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Query.Series;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Command.VideoPurchase;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Query.Comment;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // User Actions
        public async Task<IActionResult> Index()
        {
            var query = new GetAllUsersQuery<UserListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> Details(int userId)
        {
            var query = new GetUserByIdQuery<UserDetailsDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto dto)
        {
            var command = new AddUserCommand(dto.Username, dto.Email, dto.Password);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int userId)
        {

            var query = new GetUserByIdQuery<UserEditDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditDto dto)
        {
            var command = new EditUserCommand(dto.Id, dto.Username, dto.Email);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Details), new { userId = dto.Id });
        }

        public IActionResult SetNewPassword(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            var dto = new UserPasswordDto { Id = userId };

            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> SetNewPassword(UserPasswordDto dto)
        {
            var command = new NewPasswordCommand(dto.Id, dto.Password);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Details), new { userId = dto.Id });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int userId)
        {
            var command = new DeleteUserCommand(userId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }


             return RedirectToAction(nameof(Index));
        }




        // Comment Actiond


        public async Task<IActionResult> Comments(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetCommentsByUserIdQuery<CommentListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }






        // Series Actions


        public async Task<IActionResult> Series(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetSeriesByUserIdQuery<SeriesListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddSeries(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetSeriesByExcludedUserIdQuery<SeriesListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeries(int userId, List<int> seriesIds, string userUsername)
        {
            foreach (var seriesId in seriesIds)
            {
                var command = new AddSeriesPurchaseCommand(seriesId, userId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Series), new { userId, userUsername });
        }




        public async Task<IActionResult> RemoveSeries(int userId, string userUsername)
        {
            ViewBag.UserId = userId;
            ViewBag.UserUsername = userUsername;
            var query = new GetSeriesByUserIdQuery<SeriesListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSeries(int userId, List<int> seriesIds, string userUsername)
        {
            foreach (var seriesId in seriesIds)
            {
                var command = new DeleteSeriesPurchaseCommand(seriesId, userId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Series), new { userId, userUsername });
        }


        // Video Actions





        public async Task<IActionResult> Videos(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetVideosByUserIdQuery<VideoListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }



        public async Task<IActionResult> AddVideos(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetVideosByExcludedUserIdQuery<VideoListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideos(int userId, List<int> videoIds, string userUsername)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoPurchaseCommand(userId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { userId, userUsername });
        }


        public async Task<IActionResult> RemoveVideos(int userId, string userUsername)
        {
            ViewBag.UserUsername = userUsername;
            ViewBag.UserId = userId;
            var query = new GetVideosByUserIdQuery<VideoListDto>(userId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideos(int userId, List<int> videoIds, string userUsername)
        {

            foreach (var videoId in videoIds)
            {
                var command = new DeleteVideoPurchaseCommand(videoId, userId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { userId, userUsername });
        }
    }
}
