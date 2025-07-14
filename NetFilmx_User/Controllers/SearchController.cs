using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class SearchController : Controller
    {
        private readonly IApiService _apiService;

        public SearchController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(string? query = null, List<int>? categoryIds = null, string? sortBy = null)
        {
            var viewModel = new SearchViewModel
            {
                SearchQuery = query ?? string.Empty,
                SelectedCategoryIds = categoryIds ?? new List<int>(),
                SortBy = sortBy ?? "popular"
            };

            // Get all categories for filter sidebar
            var categories = await _apiService.GetAllCategoriesAsync();
            viewModel.AvailableCategories = categories?.ToList() ?? new List<CategoryListDto>();

            // Perform search if query provided
            if (!string.IsNullOrEmpty(query))
            {
                // Get all videos and filter by search term
                var allVideos = await _apiService.GetAllVideosAsync();
                
                if (allVideos != null)
                {
                    var filteredVideos = allVideos
                        .Where(v => v.Title.Contains(query, StringComparison.OrdinalIgnoreCase));

                    // Apply sorting
                    filteredVideos = sortBy switch
                    {
                        "newest" => filteredVideos.OrderByDescending(v => v.Id),
                        "price-asc" => filteredVideos.OrderBy(v => v.Price),
                        "price-desc" => filteredVideos.OrderByDescending(v => v.Price),
                        "title" => filteredVideos.OrderBy(v => v.Title),
                        _ => filteredVideos.OrderByDescending(v => v.Id) // popular (default)
                    };

                    viewModel.VideoResults = filteredVideos.ToList();
                }

                // Search series
                var allSeries = await _apiService.GetAllSeriesAsync();
                
                if (allSeries != null)
                {
                    var filteredSeries = allSeries
                        .Where(s => s.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

                    viewModel.SeriesResults = filteredSeries.ToList();
                }
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Autocomplete(string term)
        {
            if (string.IsNullOrEmpty(term) || term.Length < 2)
            {
                return Json(new List<string>());
            }

            var suggestions = new List<string>();

            // Get video suggestions
            var allVideos = await _apiService.GetAllVideosAsync();
            
            if (allVideos != null)
            {
                var videoSuggestions = allVideos
                    .Where(v => v.Title.Contains(term, StringComparison.OrdinalIgnoreCase))
                    .Select(v => v.Title)
                    .Take(5);
                
                suggestions.AddRange(videoSuggestions);
            }

            // Get series suggestions
            var allSeries = await _apiService.GetAllSeriesAsync();
            
            if (allSeries != null)
            {
                var seriesSuggestions = allSeries
                    .Where(s => s.Name.Contains(term, StringComparison.OrdinalIgnoreCase))
                    .Select(s => s.Name)
                    .Take(3);
                
                suggestions.AddRange(seriesSuggestions);
            }

            return Json(suggestions.Distinct().Take(8));
        }
    }
}