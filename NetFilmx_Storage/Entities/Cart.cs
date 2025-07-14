using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetFilmx_Storage.Entities
{
    [Table("Carts", Schema = "NetFilmx")]
    public class Cart : BaseEntity
    {
        internal Cart()
        {
            CartItems = new List<CartItem>();
        }

        public Cart(int userId) : this()
        {
            UserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;

        public virtual ICollection<CartItem> CartItems { get; set; }
    }

    [Table("CartItems", Schema = "NetFilmx")]
    public class CartItem : BaseEntity
    {
        internal CartItem()
        {
        }

        public CartItem(int cartId, int? videoId = null, int? seriesId = null)
        {
            if (videoId == null && seriesId == null)
                throw new ArgumentException("Either VideoId or SeriesId must be provided");
            
            if (videoId != null && seriesId != null)
                throw new ArgumentException("Only VideoId or SeriesId can be provided, not both");

            CartId = cartId;
            VideoId = videoId;
            SeriesId = seriesId;
            Quantity = 1;
            AddedAt = DateTime.Now;
        }

        [Required]
        public int CartId { get; set; }

        public int? VideoId { get; set; }

        public int? SeriesId { get; set; }

        [Required]
        public int Quantity { get; set; } = 1;

        [Required]
        public DateTime AddedAt { get; set; }

        // Navigation properties
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; } = null!;

        [ForeignKey("VideoId")]
        public virtual Video? Video { get; set; }

        [ForeignKey("SeriesId")]
        public virtual Series? Series { get; set; }
    }
}