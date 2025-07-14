namespace NetFilmx_Service.Dtos.Cart
{
    public class CartDetailsDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<CartItemDetailsDto> CartItems { get; set; } = new List<CartItemDetailsDto>();
        public decimal Subtotal => CartItems.Sum(item => item.Price);
        public decimal Tax => Subtotal * 0.23m; // 23% VAT
        public decimal Total => Subtotal + Tax;
        public int ItemCount => CartItems.Count;
    }
}