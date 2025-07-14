using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IApiService _apiService;

        public CategoryController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _apiService.GetAllCategoriesAsync();
            
            var viewModel = new CategoryBrowseViewModel
            {
                Categories = categories?.ToList() ?? new List<CategoryListDto>()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id, string? name = null)
        {
            var category = await _apiService.GetCategoryByIdAsync(id);
            
            if (category == null)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Category not found" });
            }

            var videos = await _apiService.GetVideosByCategoryAsync(id);

            var viewModel = new CategoryBrowseViewModel
            {
                Category = category,
                Videos = videos?.ToList() ?? new List<VideoListDto>()
            };

            return View(viewModel);
        }
    }
}