using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> AddAsync(Cart cart);
        Task<Cart?> GetByIdAsync(int id);
        Task<Cart?> GetByUserIdAsync(int userId);
        Task<Cart> GetOrCreateByUserIdAsync(int userId);
        Task UpdateAsync(Cart cart);
        Task DeleteAsync(int id);
        Task<IEnumerable<Cart>> GetAllAsync();
        
        // Cart item operations
        Task<CartItem> AddItemAsync(CartItem cartItem);
        Task<CartItem?> GetItemByIdAsync(int id);
        Task<IEnumerable<CartItem>> GetItemsByCartIdAsync(int cartId);
        Task<CartItem?> GetItemByCartAndVideoAsync(int cartId, int videoId);
        Task<CartItem?> GetItemByCartAndSeriesAsync(int cartId, int seriesId);
        Task UpdateItemAsync(CartItem cartItem);
        Task DeleteItemAsync(int id);
        Task ClearCartAsync(int cartId);
        
        // Convenience methods for command handlers
        Task AddVideoToCartAsync(int cartId, int videoId);
        Task AddSeriesToCartAsync(int cartId, int seriesId);
        Task RemoveCartItemAsync(int cartItemId);
        Task ClearCartByUserIdAsync(int userId);
    }
}