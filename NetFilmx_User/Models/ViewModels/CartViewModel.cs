using System.ComponentModel.DataAnnotations;

namespace NetFilmx_User.Models.ViewModels
{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal Subtotal { get; private set; }
        public decimal Tax { get; private set; }
        public decimal Total { get; private set; }
        public decimal Discount { get; set; }
        public string? PromoCode { get; set; }

        public void CalculateTotals()
        {
            Subtotal = Items.Sum(i => i.Price);
            Tax = Subtotal * 0.23m; // 23% VAT
            Total = Subtotal + Tax - Discount;
        }

        public int ItemCount => Items.Count;
        public bool HasItems => Items.Any();
    }

    public class CartItemViewModel
    {
        public string Id { get; set; } = string.Empty;
        public int? VideoId { get; set; }
        public int? SeriesId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string ItemType { get; set; } = string.Empty; // "Video" or "Series"
        public int Quantity { get; set; } = 1;
    }

    public class CartItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int? VideoId { get; set; }
        public int? SeriesId { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;
    }
}