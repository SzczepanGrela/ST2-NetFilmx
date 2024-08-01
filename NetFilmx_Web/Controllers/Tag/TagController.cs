﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.Tag;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Dtos.Tag;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Tag;
using NetFilmx_Service.Query.Video;

namespace NetFilmx_Web.Controllers
{
    public class TagController : Controller
    {
        private readonly IMediator _mediator;

        public TagController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllTagsQuery<TagListDto>();
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return View(result.Data);
        }

        public async Task<IActionResult> Details(int tagId)
        {
            var query = new GetTagByIdQuery<TagDetailsDto>(tagId);
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
        public async Task<IActionResult> Add(TagAddDto dto)
        {
            var command = new AddTagCommand(dto.Name);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int tagId)
        {
            var query = new GetTagByIdQuery<TagEditDto>(tagId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TagEditDto dto)
        {
            var command = new EditTagCommand(dto.Id, dto.Name);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return RedirectToAction(nameof(Details), new { tagId = dto.Id });
        }

        public async Task<IActionResult> Videos(int tagId, string tagName)
        {
            ViewBag.TagName = tagName;
            ViewBag.TagId = tagId;
            var query = new GetVideosByTagIdQuery<VideoListDto>(tagId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddVideos(int tagId, string tagName)
        {
            ViewBag.TagName = tagName;
            ViewBag.TagId = tagId;
            var query = new GetVideosByExcludedTagIdQuery<VideoListDto>(tagId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideos(int tagId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoToTagCommand(tagId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { tagId });
        }

        public async Task<IActionResult> RemoveVideos(int tagId, string tagName)
        {
            ViewBag.TagId = tagId;
            ViewBag.TagName = tagName;
            var query = new GetVideosByTagIdQuery<VideoListDto>(tagId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideos(int tagId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new RemoveVideoFromTagCommand(tagId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { tagId });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int tagId)
        {
            var command = new DeleteTagCommand(tagId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
