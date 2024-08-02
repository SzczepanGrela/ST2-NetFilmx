﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Query.Category;
using NetFilmx_Service.Query.Video;
using NetFilmx_Service.Query.Video;

namespace NetFilmx_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllCategoriesQuery<CategoryListDto>();
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
        public async Task<IActionResult> Add(CategoryAddDto dto)
        {
            var command = new AddCategoryCommand(dto.Name, dto.Description);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }


            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> Details(int categoryId)
        {
            var query = new GetCategoryByIdQuery<CategoryDetailsDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            
            return View(result.Data);
        }

        public async Task<IActionResult> Edit(int categoryId)
        {
            var query = new GetCategoryByIdQuery<CategoryEditDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
          
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditDto dto)
        {
            var command = new EditCategoryCommand(dto.Id, dto.Name, dto.Description);
            var result = await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }


            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> Videos(int categoryId, string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            ViewBag.CategoryId = categoryId;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddVideos(int categoryId, string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            ViewBag.CategoryId = categoryId;
            var query = new GetVideosByExcludedCategoryQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideos(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoToCategoryCommand(categoryId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message});
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }

        public async Task<IActionResult> RemoveVideos(int categoryId, string categoryName)
        {
            ViewBag.CategoryId = categoryId;
            ViewBag.CategoryName = categoryName;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideos(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new RemoveVideoFromCategoryCommand(categoryId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            ViewBag.Steps = 2;

            return View("~/Views/Shared/RedirectBack.cshtml");
        }
    }
}
