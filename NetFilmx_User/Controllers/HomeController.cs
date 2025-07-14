using Microsoft.AspNetCore.Mvc;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            // Get trending videos
            var allVideos = await _apiService.GetAllVideosAsync();
            if (allVideos != null)
            {
                var videoList = allVideos.ToList();
                viewModel.TrendingVideos = videoList.Take(10).ToList();
                viewModel.FeaturedVideo = videoList.FirstOrDefault();
                viewModel.NewReleases = videoList.Skip(10).Take(10).ToList();
            }

            // Get categories for browsing
            var categories = await _apiService.GetAllCategoriesAsync();
            if (categories != null)
            {
                viewModel.PopularCategories = categories.Take(8).ToList();
            }

            // Get series
            var series = await _apiService.GetAllSeriesAsync();
            if (series != null)
            {
                viewModel.PopularSeries = series.Take(6).ToList();
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string? errorMessage = null, List<string>? errors = null)
        {
            var viewModel = new NetFilmx_User.Models.ErrorViewModel
            {
                RequestId = HttpContext.TraceIdentifier,
                ErrorMessage = errorMessage,
                Errors = errors ?? new List<string>()
            };
            return View(viewModel);
        }
    }
}