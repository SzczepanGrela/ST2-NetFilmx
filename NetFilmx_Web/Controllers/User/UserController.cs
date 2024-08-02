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
            var command = new EditUserCommand(dto.Id, dto.Username, dto.Email, dto.Password);
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

        // Series Actions
        public IActionResult AddSeries()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeries(SeriesAddDto dto)
        {
            var command = new AddSeriesCommand(dto.Name, dto.Description, dto.Price);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveSeries(int seriesId)
        {
            var query = new GetSeriesByIdQuery<SeriesListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost, ActionName("RemoveSeries")]
        public async Task<IActionResult> RemoveSeriesConfirmed(int seriesId, int userId)
        {
            var command = new DeleteSeriesPurchaseCommand(seriesId, userId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        // Video Actions
        public IActionResult AddVideos()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddVideos(VideoAddDto dto)
        {
            var command = new AddVideoCommand(dto.Title, dto.Description, dto.Price, dto.VideoUrl, dto.ThumbnailUrl);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemoveVideos(int videoId)
        {
            var query = new GetVideoByIdQuery<VideoListDto>(videoId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost, ActionName("RemoveVideos")]
        public async Task<IActionResult> RemoveVideosConfirmed(int videoId, int userId)
        {
            var command = new DeleteVideoPurchaseCommand(videoId, userId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
