using NetFilmx_User.Models.ViewModels;
using NetFilmx_Service.Dtos.Cart;

namespace NetFilmx_User.Services
{
    public interface ICartService
    {
        Task<CartDetailsDto?> GetCartAsync(int userId);
        Task<bool> AddVideoAsync(int userId, int videoId);
        Task<bool> AddSeriesAsync(int userId, int seriesId);
        Task<bool> RemoveItemAsync(int cartItemId);
        Task<bool> ClearCartAsync(int userId);
        Task<int> GetItemCountAsync(int userId);
        Task<bool> HasItemAsync(int userId, int? videoId, int? seriesId);
    }
}