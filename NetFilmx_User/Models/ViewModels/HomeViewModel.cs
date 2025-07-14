using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Series;

namespace NetFilmx_User.Models.ViewModels
{
    public class HomeViewModel
    {
        public VideoListDto? FeaturedVideo { get; set; }
        public List<VideoListDto> TrendingVideos { get; set; } = new List<VideoListDto>();
        public List<VideoListDto> NewReleases { get; set; } = new List<VideoListDto>();
        public List<CategoryListDto> PopularCategories { get; set; } = new List<CategoryListDto>();
        public List<SeriesListDto> PopularSeries { get; set; } = new List<SeriesListDto>();
        public List<VideoListDto> ContinueWatching { get; set; } = new List<VideoListDto>(); // For logged in users
    }
}