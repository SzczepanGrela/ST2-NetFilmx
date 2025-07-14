using Microsoft.EntityFrameworkCore;
using NetFilmx_Storage.Context;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly NetFilmxDbContext _context;

        public CartRepository(NetFilmxDbContext context)
        {
            _context = context;
        }

        public async Task<Cart> AddAsync(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart?> GetByIdAsync(int id)
        {
            return await _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Video)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Series)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cart?> GetByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Video)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Series)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> GetOrCreateByUserIdAsync(int userId)
        {
            var cart = await GetByUserIdAsync(userId);
            if (cart == null)
            {
                cart = new Cart(userId);
                await AddAsync(cart);
            }
            return cart;
        }

        public async Task UpdateAsync(Cart cart)
        {
            cart.UpdatedAt = DateTime.Now;
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await _context.Carts
                .Include(c => c.User)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Video)
                .Include(c => c.CartItems)
                    .ThenInclude(ci => ci.Series)
                .ToListAsync();
        }

        // Cart item operations
        public async Task<CartItem> AddItemAsync(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            // Update cart timestamp
            var cart = await _context.Carts.FindAsync(cartItem.CartId);
            if (cart != null)
            {
                cart.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return cartItem;
        }

        public async Task<CartItem?> GetItemByIdAsync(int id)
        {
            return await _context.CartItems
                .Include(ci => ci.Cart)
                .Include(ci => ci.Video)
                .Include(ci => ci.Series)
                .FirstOrDefaultAsync(ci => ci.Id == id);
        }

        public async Task<IEnumerable<CartItem>> GetItemsByCartIdAsync(int cartId)
        {
            return await _context.CartItems
                .Include(ci => ci.Video)
                .Include(ci => ci.Series)
                .Where(ci => ci.CartId == cartId)
                .OrderByDescending(ci => ci.AddedAt)
                .ToListAsync();
        }

        public async Task<CartItem?> GetItemByCartAndVideoAsync(int cartId, int videoId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.VideoId == videoId);
        }

        public async Task<CartItem?> GetItemByCartAndSeriesAsync(int cartId, int seriesId)
        {
            return await _context.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.SeriesId == seriesId);
        }

        public async Task UpdateItemAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();

            // Update cart timestamp
            var cart = await _context.Carts.FindAsync(cartItem.CartId);
            if (cart != null)
            {
                cart.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
                var cartId = cartItem.CartId;
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();

                // Update cart timestamp
                var cart = await _context.Carts.FindAsync(cartId);
                if (cart != null)
                {
                    cart.UpdatedAt = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cartItems = await _context.CartItems.Where(ci => ci.CartId == cartId).ToListAsync();
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // Update cart timestamp
            var cart = await _context.Carts.FindAsync(cartId);
            if (cart != null)
            {
                cart.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
        }

        // Convenience methods for command handlers
        public async Task AddVideoToCartAsync(int cartId, int videoId)
        {
            var cartItem = new CartItem(cartId, videoId);
            await AddItemAsync(cartItem);
        }

        public async Task AddSeriesToCartAsync(int cartId, int seriesId)
        {
            var cartItem = new CartItem(cartId, null, seriesId);
            await AddItemAsync(cartItem);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            await DeleteItemAsync(cartItemId);
        }

        public async Task ClearCartByUserIdAsync(int userId)
        {
            var cart = await GetByUserIdAsync(userId);
            if (cart != null)
            {
                await ClearCartAsync(cart.Id);
            }
        }
    }
}