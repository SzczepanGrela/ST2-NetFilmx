using System.ComponentModel.DataAnnotations;

namespace NetFilmx_User.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
        
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "City")]
        public string City { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; } = "Poland";
        
        [Required]
        [Display(Name = "Card Number")]
        [CreditCard]
        public string CardNumber { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Expiry Month")]
        [Range(1, 12)]
        public int ExpiryMonth { get; set; }
        
        [Required]
        [Display(Name = "Expiry Year")]
        [Range(2024, 2034)]
        public int ExpiryYear { get; set; }
        
        [Required]
        [Display(Name = "CVV")]
        [StringLength(4, MinimumLength = 3)]
        public string CVV { get; set; } = string.Empty;
        
        [Display(Name = "Cardholder Name")]
        public string CardholderName { get; set; } = string.Empty;

        public decimal Subtotal { get; private set; }
        public decimal Tax { get; private set; }
        public decimal Total { get; private set; }
        public decimal Discount { get; set; }

        public void CalculateTotals()
        {
            Subtotal = CartItems.Sum(i => i.Price);
            Tax = Subtotal * 0.23m; // 23% VAT
            Total = Subtotal + Tax - Discount;
        }
    }
}