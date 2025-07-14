using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class SeriesController : Controller
    {
        private readonly IApiService _apiService;

        public SeriesController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var series = await _apiService.GetAllSeriesAsync();
            return View(series?.ToList() ?? new List<SeriesListDto>());
        }

        public async Task<IActionResult> Details(int id)
        {
            var series = await _apiService.GetSeriesByIdAsync(id);
            
            if (series == null)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Series not found" });
            }

            var episodes = await _apiService.GetVideosBySeriesAsync(id);

            var viewModel = new SeriesDetailViewModel
            {
                Series = series,
                Episodes = episodes?.ToList() ?? new List<VideoListDto>()
            };

            return View(viewModel);
        }
    }
}