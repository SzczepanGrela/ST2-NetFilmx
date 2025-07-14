namespace NetFilmx_Service.Dtos.Cart
{
    public class CartItemDetailsDto
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int? VideoId { get; set; }
        public int? SeriesId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
        
        // Content details
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string ItemType { get; set; } = string.Empty; // "Video" or "Series"
    }
}