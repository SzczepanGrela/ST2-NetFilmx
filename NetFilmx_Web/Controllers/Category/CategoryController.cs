using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service;
using NetFilmx_Service.Command.Category;
using NetFilmx_Service.Command.Video;
using NetFilmx_Service.Command.Video.RemoveVideoFromCategory;
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

        public async Task<IActionResult> Details(int id)
        {
            var query = new GetCategoryByIdQuery<CategoryDetailsDto>(id);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            
            return View(result.Data);
        }

        public async Task<IActionResult> Edit(string name)
        {
            var query = new GetCategoryByNameQuery<CategoryEditDto>(name);
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
            var result = (CResult)await _mediator.Send(command);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return RedirectToAction(nameof(Details), new { id = dto.Id });
        }

        public async Task<IActionResult> Videos(int categoryId, string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        public async Task<IActionResult> AddVideo(int categoryId)
        {
            ViewBag.CategoryName = categoryId;
            var query = new GetVideosByExcludedCategoryQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoToCategoryCommand(categoryId, videoId);
                var result = (CResult)await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { categoryId });
        }

        public async Task<IActionResult> RemoveVideo(int categoryId)
        {
            ViewBag.CategoryName = categoryId;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            if (result.IsFailure)
            {
                return RedirectToAction("Error", "Home", new { Message = result.Message });
            }
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideo(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new RemoveVideoFromCategoryCommand(categoryId, videoId);
                var result = (CResult)await _mediator.Send(command);
                if (result.IsFailure)
                {
                    return RedirectToAction("Error", "Home", new { Message = result.Message });
                }
            }
            return RedirectToAction(nameof(Videos), new { categoryId });
        }
    }
}
