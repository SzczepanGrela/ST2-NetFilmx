using NetFilmx_Service.Dtos.Video;
using NetFilmx_Service.Dtos.Category;
using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Comment;
using NetFilmx_Service.Dtos.Cart;
using NetFilmx_Service.Dtos.ViewHistory;
using NetFilmx_Service.Dtos.UserSettings;
using NetFilmx_Service.Dtos.Favorite;
using NetFilmx_Service.Dtos.User;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;

namespace NetFilmx_User.Services
{
    public interface IApiService
    {
        // Video endpoints
        Task<IEnumerable<VideoListDto>?> GetAllVideosAsync();
        Task<VideoDetailsDto?> GetVideoByIdAsync(int id);
        Task<IEnumerable<VideoListDto>?> GetVideosByCategoryAsync(int categoryId);
        Task<IEnumerable<VideoListDto>?> GetVideosBySeriesAsync(int seriesId);

        // Category endpoints
        Task<IEnumerable<CategoryListDto>?> GetAllCategoriesAsync();
        Task<CategoryDetailsDto?> GetCategoryByIdAsync(int id);

        // Series endpoints
        Task<IEnumerable<SeriesListDto>?> GetAllSeriesAsync();
        Task<SeriesDetailsDto?> GetSeriesByIdAsync(int id);

        // Comment endpoints
        Task<IEnumerable<CommentListDto>?> GetCommentsByVideoAsync(int videoId);
        Task<int> GetLikesCountByVideoAsync(int videoId);

        // User Settings endpoints
        Task<UserSettingsDetailsDto?> GetUserSettingsAsync(int userId);
        Task<bool> UpdateUserSettingsAsync(int userId, UserSettingsDetailsDto settings);

        // Favorites endpoints
        Task<IEnumerable<FavoriteListDto>?> GetUserFavoritesAsync(int userId);
        Task<bool> AddVideoToFavoritesAsync(int userId, int videoId);
        Task<bool> AddSeriesToFavoritesAsync(int userId, int seriesId);
        Task<bool> RemoveFromFavoritesAsync(int favoriteId);

        // Cart endpoints
        Task<CartDetailsDto?> GetUserCartAsync(int userId);
        Task<bool> AddVideoToCartAsync(int userId, int videoId);
        Task<bool> AddSeriesToCartAsync(int userId, int seriesId);
        Task<bool> RemoveCartItemAsync(int cartItemId);
        Task<bool> ClearCartAsync(int userId);
        Task<int> GetCartItemCountAsync(int userId);

        // ViewHistory endpoints
        Task<IEnumerable<ViewHistoryDetailsDto>?> GetUserViewHistoryAsync(int userId);
        Task<IEnumerable<ViewHistoryDetailsDto>?> GetContinueWatchingAsync(int userId);
        Task<bool> RecordViewingProgressAsync(int userId, int videoId, int progressSeconds, int durationSeconds);
        Task<bool> MarkVideoCompletedAsync(int userId, int videoId);
        Task<bool> RemoveFromViewHistoryAsync(int viewHistoryId);
        Task<bool> ClearViewHistoryAsync(int userId);

        // User Profile endpoints
        Task<UserDetailsDto?> GetUserProfileAsync(int userId);
        Task<bool> UpdateUserProfileAsync(int userId, UserEditDto userEdit);

        // Purchase History endpoints
        Task<IEnumerable<VideoPurchaseDetailsDto>?> GetUserVideoPurchasesAsync(int userId);
        Task<IEnumerable<SeriesPurchaseDetailsDto>?> GetUserSeriesPurchasesAsync(int userId);
    }
}