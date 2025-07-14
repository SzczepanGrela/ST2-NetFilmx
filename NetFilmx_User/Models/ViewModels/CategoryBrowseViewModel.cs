using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Video;

namespace NetFilmx_User.Models.ViewModels
{
    public class CategoryBrowseViewModel
    {
        // For category listing page
        public List<CategoryListDto> Categories { get; set; } = new List<CategoryListDto>();
        
        // For individual category browsing
        public CategoryDetailsDto? Category { get; set; }
        public List<VideoListDto> Videos { get; set; } = new List<VideoListDto>();
        public string SortBy { get; set; } = "popular";
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalCount => Videos.Count;
    }
}