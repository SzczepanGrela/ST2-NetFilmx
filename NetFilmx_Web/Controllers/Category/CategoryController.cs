using MediatR;
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

namespace NetFilmx_Web.Controllers.Category
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
            if (Request.Headers.TryGetValue("Referer", out var referer))
            {
                return Redirect(referer.ToString());
            }
            
            return RedirectToAction(nameof(Details), new { categoryId = dto.Id });
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
            return RedirectToAction(nameof(Videos), new { categoryId });
        }

        public async Task<IActionResult> DeleteVideos(int categoryId, string categoryName)
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
        public async Task<IActionResult> DeleteVideos(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new DeleteVideoFromCategoryCommand(categoryId, videoId);
                var result = await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { categoryId });
        }
    }
}
