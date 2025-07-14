namespace NetFilmx_Service.Dtos.Favorite
{
    public class FavoriteListDto : IFavoriteDto
    {
        public FavoriteListDto(int id, int userId, int? videoId, int? seriesId, DateTime createdAt,
            string? videoTitle = null, string? seriesName = null, string? thumbnailUrl = null, decimal? price = null)
        {
            Id = id;
            UserId = userId;
            VideoId = videoId;
            SeriesId = seriesId;
            CreatedAt = createdAt;
            VideoTitle = videoTitle;
            SeriesName = seriesName;
            ThumbnailUrl = thumbnailUrl;
            Price = price;
        }

        public int Id { get; }
        public int UserId { get; }
        public int? VideoId { get; }
        public int? SeriesId { get; }
        public DateTime CreatedAt { get; }
        
        // Additional properties for display
        public string? VideoTitle { get; }
        public string? SeriesName { get; }
        public string? ThumbnailUrl { get; }
        public decimal? Price { get; }
        
        public string ItemType => VideoId.HasValue ? "Video" : "Series";
        public string Title => VideoTitle ?? SeriesName ?? "Unknown";
    }
}