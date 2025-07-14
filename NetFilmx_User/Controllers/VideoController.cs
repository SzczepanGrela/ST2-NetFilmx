using Microsoft.AspNetCore.Mvc;
using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_User.Models.ViewModels;
using NetFilmx_User.Services;

namespace NetFilmx_User.Controllers
{
    public class VideoController : Controller
    {
        private readonly IApiService _apiService;

        public VideoController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var video = await _apiService.GetVideoByIdAsync(id);
            
            if (video == null)
            {
                return RedirectToAction("Error", "Home", new { errorMessage = "Video not found" });
            }

            var viewModel = new VideoDetailViewModel
            {
                Video = video
            };

            // Get comments for this video
            var comments = await _apiService.GetCommentsByVideoAsync(id);
            viewModel.Comments = comments?.ToList() ?? new List<CommentListDto>();

            // Get likes count
            viewModel.LikesCount = await _apiService.GetLikesCountByVideoAsync(id);

            // Get related videos (same category or series)
            var allVideos = await _apiService.GetAllVideosAsync();
            if (allVideos != null)
            {
                viewModel.RelatedVideos = allVideos.Where(v => v.Id != id).Take(6).ToList();
            }
            else
            {
                viewModel.RelatedVideos = new List<VideoListDto>();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Browse()
        {
            var videos = await _apiService.GetAllVideosAsync();
            return View(videos?.ToList() ?? new List<VideoListDto>());
        }
    }
}