using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Command.Category.Add;
using NetFilmx_Service.Command.Category.Delete;
using NetFilmx_Service.Command.Category.Edit;
using NetFilmx_Service.Command.Video.AddVideoToCategory;
using NetFilmx_Service.Command.Video.RemoveVideoFromCategory;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Query.Category.GetAll;
using NetFilmx_Service.Query.Category.GetById;
using NetFilmx_Service.Query.Category.GetByName;
using NetFilmx_Service.Query.Video.GetByCategoryId;
using NetFilmx_Service.Query.Video.GetByExclCategoryId;

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
            return View(result);
        }

        public async Task<IActionResult> Details(string name)
        {
            var query = new GetCategoryByNameQuery<CategoryDetailsDto>(name);
            var result = await _mediator.Send(query);
            return View(result);
        }

        public async Task<IActionResult> Edit(string name)
        {
            var query = new GetCategoryByNameQuery<CategoryEditDto>(name);
            var result = await _mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditDto dto)
        {
            var command = new EditCategoryCommand(dto.Id, dto.Name, dto.Description);
            var result = await _mediator.Send(command);
            return RedirectToAction(nameof(Details), new { name = dto.Name });
        }

        public async Task<IActionResult> Videos(int categoryId, string categoryName)
        {
            ViewBag.CategoryName = categoryName;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            return View(result);
        }

        public async Task<IActionResult> AddVideo(int categoryId)
        {
            ViewBag.CategoryName = categoryId;
            var query = new GetVideosByExcludedCategoryQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new AddVideoToCategoryCommand(categoryId, videoId);
                await _mediator.Send(command);
            }
            return RedirectToAction(nameof(Videos), new { categoryId });
        }

        public async Task<IActionResult> RemoveVideo(int categoryId)
        {
            ViewBag.CategoryName = categoryId;
            var query = new GetVideosByCategoryIdQuery<VideoListDto>(categoryId);
            var result = await _mediator.Send(query);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveVideo(int categoryId, List<int> videoIds)
        {
            foreach (var videoId in videoIds)
            {
                var command = new RemoveVideoFromCategoryCommand(categoryId, videoId);
                await _mediator.Send(command);
            }
            return RedirectToAction(nameof(Videos), new { categoryId });
        }
    }
}
