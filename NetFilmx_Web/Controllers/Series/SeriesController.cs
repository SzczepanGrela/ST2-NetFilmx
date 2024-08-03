﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.Series;
using NetFilmx_Service.Command.SeriesPurchase;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Series;
using NetFilmx_Service.Query.User;
using NetFilmx_Service.Query.Video;

namespace NetFilmx_Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IMediator _mediator;

        public SeriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllSeriesQuery<SeriesListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Details(int seriesId)
        {
            var query = new GetSeriesByIdQuery<SeriesDetailsDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Edit(int seriesId)
        {
            var query = new GetSeriesByIdQuery<SeriesEditDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeriesEditDto dto)
        {
            var command = new EditSeriesCommand(dto.Id, dto.Name, dto.Description, dto.Price);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }

            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> Videos(int seriesId, string seriesName)
        {
            ViewBag.SeriesName = seriesName;
            ViewBag.SeriesId = seriesId;
            var query = new GetVideosBySeriesIdQuery<VideoListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddVideos(int seriesId, string seriesName)
        {
            ViewBag.SeriesName = seriesName;
            ViewBag.SeriesId = seriesId;
            var query = new GetVideosByExcludedSeriesQuery<VideoListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideos(int seriesId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoToSeriesCommand(seriesId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> RemoveVideos(int seriesId, string seriesName)
        {
            ViewBag.SeriesId = seriesId;
            ViewBag.SeriesName = seriesName;
            var query = new GetVideosBySeriesIdQuery<VideoListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideos(int seriesId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new RemoveVideoFromSeriesCommand(seriesId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> Users(int seriesId, string seriesName)
        {
            ViewBag.SeriesName = seriesName;
            ViewBag.SeriesId = seriesId;
            var query = new GetUsersBySeriesIdQuery<UserListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddUsers(int seriesId, string seriesName)
        {
            ViewBag.SeriesName = seriesName;
            ViewBag.SeriesId = seriesId;
            var query = new GetUsersByExcludedSeriesIdQuery<UserListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(int seriesId, List<int> userIds)
        {
            foreach (var userId in userIds)
            {
                var command = new AddSeriesPurchaseCommand(seriesId, userId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> RemoveUsers(int seriesId, string seriesName)
        {
            ViewBag.SeriesId = seriesId;
            ViewBag.SeriesName = seriesName;
            var query = new GetUsersBySeriesIdQuery<UserListDto>(seriesId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUsers(int seriesId, List<int> userIds)
        {
            foreach (var userId in userIds)
            {
                var command = new DeleteSeriesPurchaseCommand(seriesId, userId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml"); ;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int seriesId)
        {
            var command = new DeleteSeriesCommand(seriesId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = result.Message, errors = result.Errors });
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeriesAddDto dto)
        {
            var command = new AddSeriesCommand(dto.Name, dto.Description, dto.Price);
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
