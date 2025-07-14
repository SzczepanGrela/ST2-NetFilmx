using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Category;

namespace NetFilmx_User.Models.ViewModels
{
    public class SearchViewModel
    {
        public string SearchQuery { get; set; } = string.Empty;
        public List<VideoListDto> VideoResults { get; set; } = new List<VideoListDto>();
        public List<SeriesListDto> SeriesResults { get; set; } = new List<SeriesListDto>();
        public List<CategoryListDto> AvailableCategories { get; set; } = new List<CategoryListDto>();
        public List<int> SelectedCategoryIds { get; set; } = new List<int>();
        public string SortBy { get; set; } = "popular";
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinRating { get; set; }
        public string ContentType { get; set; } = "all"; // "all", "videos", "series"
        
        public int TotalResults => VideoResults.Count + SeriesResults.Count;
    }
}