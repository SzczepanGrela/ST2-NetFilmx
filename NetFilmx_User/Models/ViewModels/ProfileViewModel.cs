using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Dtos.Video;

namespace NetFilmx_User.Models.ViewModels
{
    public class ProfileViewModel
    {
        public UserDetailsDto User { get; set; } = null!;
        public int TotalPurchases { get; set; }
        public decimal TotalSpent { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public bool EmailNotifications { get; set; } = true;
        public bool AutoplayEnabled { get; set; } = true;
        public string? ProfileImageUrl { get; set; }
        public List<VideoListDto> RecommendedVideos { get; set; } = new List<VideoListDto>();
        public List<VideoListDto> TrendingVideos { get; set; } = new List<VideoListDto>();
    }

    public class PurchaseHistoryViewModel
    {
        public List<VideoPurchaseDetailsDto> VideoPurchases { get; set; } = new List<VideoPurchaseDetailsDto>();
        public List<SeriesPurchaseDetailsDto> SeriesPurchases { get; set; } = new List<SeriesPurchaseDetailsDto>();
        
        public int TotalPurchases => VideoPurchases.Count + SeriesPurchases.Count;
        public decimal TotalSpent => SeriesPurchases.Count * 29.99m; // Simplified calculation
    }
}