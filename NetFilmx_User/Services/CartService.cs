using NetFilmx_User.Models.ViewModels;
using NetFilmx_Service.Dtos.Cart;
using System.Text.Json;

namespace NetFilmx_User.Services
{
    public class CartService : ICartService
    {
        private readonly IApiService _apiService;

        public CartService(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<CartDetailsDto?> GetCartAsync(int userId)
        {
            return await _apiService.GetUserCartAsync(userId);
        }

        public async Task<bool> AddVideoAsync(int userId, int videoId)
        {
            return await _apiService.AddVideoToCartAsync(userId, videoId);
        }

        public async Task<bool> AddSeriesAsync(int userId, int seriesId)
        {
            return await _apiService.AddSeriesToCartAsync(userId, seriesId);
        }

        public async Task<bool> RemoveItemAsync(int cartItemId)
        {
            return await _apiService.RemoveCartItemAsync(cartItemId);
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            return await _apiService.ClearCartAsync(userId);
        }

        public async Task<int> GetItemCountAsync(int userId)
        {
            return await _apiService.GetCartItemCountAsync(userId);
        }

        public async Task<bool> HasItemAsync(int userId, int? videoId, int? seriesId)
        {
            var cart = await GetCartAsync(userId);
            if (cart == null) return false;
            
            if (videoId.HasValue)
            {
                return cart.CartItems.Any(item => item.VideoId == videoId.Value);
            }
            
            if (seriesId.HasValue)
            {
                return cart.CartItems.Any(item => item.SeriesId == seriesId.Value);
            }
            
            return false;
        }
    }
}