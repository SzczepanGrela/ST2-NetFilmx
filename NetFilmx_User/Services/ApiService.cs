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
using System.Text;
using System.Text.Json;

namespace NetFilmx_User.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("NetFilmxAPI");
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IEnumerable<VideoListDto>?> GetAllVideosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/video");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<VideoListDto>>(json, _jsonOptions);
                }
                return new List<VideoListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching videos: {ex.Message}");
                return new List<VideoListDto>();
            }
        }

        public async Task<VideoDetailsDto?> GetVideoByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/video/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<VideoDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching video {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<VideoListDto>?> GetVideosByCategoryAsync(int categoryId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/video/category/{categoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<VideoListDto>>(json, _jsonOptions);
                }
                return new List<VideoListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching videos by category {categoryId}: {ex.Message}");
                return new List<VideoListDto>();
            }
        }

        public async Task<IEnumerable<VideoListDto>?> GetVideosBySeriesAsync(int seriesId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/video/series/{seriesId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<VideoListDto>>(json, _jsonOptions);
                }
                return new List<VideoListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching videos by series {seriesId}: {ex.Message}");
                return new List<VideoListDto>();
            }
        }

        public async Task<IEnumerable<CategoryListDto>?> GetAllCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/category");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<CategoryListDto>>(json, _jsonOptions);
                }
                return new List<CategoryListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching categories: {ex.Message}");
                return new List<CategoryListDto>();
            }
        }

        public async Task<CategoryDetailsDto?> GetCategoryByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/category/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<CategoryDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching category {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<SeriesListDto>?> GetAllSeriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/series");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<SeriesListDto>>(json, _jsonOptions);
                }
                return new List<SeriesListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching series: {ex.Message}");
                return new List<SeriesListDto>();
            }
        }

        public async Task<SeriesDetailsDto?> GetSeriesByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/series/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<SeriesDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching series {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<CommentListDto>?> GetCommentsByVideoAsync(int videoId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/comment/video/{videoId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<CommentListDto>>(json, _jsonOptions);
                }
                return new List<CommentListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching comments for video {videoId}: {ex.Message}");
                return new List<CommentListDto>();
            }
        }

        public async Task<int> GetLikesCountByVideoAsync(int videoId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/like/video/{videoId}/count");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<int>(json, _jsonOptions);
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching likes count for video {videoId}: {ex.Message}");
                return 0;
            }
        }

        public async Task<UserSettingsDetailsDto?> GetUserSettingsAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/usersettings/user/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserSettingsDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user settings for user {userId}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateUserSettingsAsync(int userId, UserSettingsDetailsDto settings)
        {
            try
            {
                var requestBody = new
                {
                    EmailNotifications = settings.EmailNotifications,
                    AutoplayEnabled = settings.AutoplayEnabled,
                    Theme = settings.Theme,
                    Language = settings.Language
                };
                var json = JsonSerializer.Serialize(requestBody, _jsonOptions);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/usersettings/user/{userId}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user settings for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<FavoriteListDto>?> GetUserFavoritesAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/favorite/user/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<FavoriteListDto>>(json, _jsonOptions);
                }
                return new List<FavoriteListDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching favorites for user {userId}: {ex.Message}");
                return new List<FavoriteListDto>();
            }
        }

        public async Task<bool> AddVideoToFavoritesAsync(int userId, int videoId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"api/favorite/user/{userId}/video/{videoId}", null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding video {videoId} to favorites for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AddSeriesToFavoritesAsync(int userId, int seriesId)
        {
            try
            {
                var response = await _httpClient.PostAsync($"api/favorite/user/{userId}/series/{seriesId}", null);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding series {seriesId} to favorites for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RemoveFromFavoritesAsync(int favoriteId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/favorite/{favoriteId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing favorite {favoriteId}: {ex.Message}");
                return false;
            }
        }

        public async Task<CartDetailsDto?> GetUserCartAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/cart/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<CartDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cart for user {userId}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> AddVideoToCartAsync(int userId, int videoId)
        {
            try
            {
                var requestBody = new { UserId = userId, VideoId = videoId };
                var json = JsonSerializer.Serialize(requestBody, _jsonOptions);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/cart/add-video", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding video {videoId} to cart for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> AddSeriesToCartAsync(int userId, int seriesId)
        {
            try
            {
                var requestBody = new { UserId = userId, SeriesId = seriesId };
                var json = JsonSerializer.Serialize(requestBody, _jsonOptions);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/cart/add-series", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding series {seriesId} to cart for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/cart/item/{cartItemId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing cart item {cartItemId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ClearCartAsync(int userId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/cart/{userId}/clear");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing cart for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<int> GetCartItemCountAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/cart/{userId}/count");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonSerializer.Deserialize<dynamic>(json, _jsonOptions);
                    return result?.GetProperty("count").GetInt32() ?? 0;
                }
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cart item count for user {userId}: {ex.Message}");
                return 0;
            }
        }

        public async Task<IEnumerable<ViewHistoryDetailsDto>?> GetUserViewHistoryAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/viewhistory/user/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<ViewHistoryDetailsDto>>(json, _jsonOptions);
                }
                return new List<ViewHistoryDetailsDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching view history for user {userId}: {ex.Message}");
                return new List<ViewHistoryDetailsDto>();
            }
        }

        public async Task<IEnumerable<ViewHistoryDetailsDto>?> GetContinueWatchingAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/viewhistory/user/{userId}/continue-watching");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<ViewHistoryDetailsDto>>(json, _jsonOptions);
                }
                return new List<ViewHistoryDetailsDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching continue watching for user {userId}: {ex.Message}");
                return new List<ViewHistoryDetailsDto>();
            }
        }

        public async Task<bool> RecordViewingProgressAsync(int userId, int videoId, int progressSeconds, int durationSeconds)
        {
            try
            {
                var requestBody = new 
                { 
                    UserId = userId, 
                    VideoId = videoId, 
                    ProgressSeconds = progressSeconds,
                    DurationSeconds = durationSeconds
                };
                var json = JsonSerializer.Serialize(requestBody, _jsonOptions);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/viewhistory/record", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error recording viewing progress for user {userId}, video {videoId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MarkVideoCompletedAsync(int userId, int videoId)
        {
            try
            {
                var requestBody = new { UserId = userId, VideoId = videoId };
                var json = JsonSerializer.Serialize(requestBody, _jsonOptions);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/viewhistory/complete", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error marking video {videoId} as completed for user {userId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> RemoveFromViewHistoryAsync(int viewHistoryId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/viewhistory/{viewHistoryId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error removing view history item {viewHistoryId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> ClearViewHistoryAsync(int userId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/viewhistory/user/{userId}/clear");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing view history for user {userId}: {ex.Message}");
                return false;
            }
        }

        // User Profile endpoints
        public async Task<UserDetailsDto?> GetUserProfileAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/auth/profile/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserDetailsDto>(json, _jsonOptions);
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user profile for user {userId}: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateUserProfileAsync(int userId, UserEditDto userEdit)
        {
            try
            {
                var jsonContent = JsonSerializer.Serialize(new
                {
                    Username = userEdit.Username,
                    Email = userEdit.Email
                }, _jsonOptions);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/auth/profile/{userId}", content);
                
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating user profile for user {userId}: {ex.Message}");
                return false;
            }
        }

        // Purchase History endpoints
        public async Task<IEnumerable<VideoPurchaseDetailsDto>?> GetUserVideoPurchasesAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/purchase/video/user/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<VideoPurchaseDetailsDto>>(json, _jsonOptions);
                }
                return new List<VideoPurchaseDetailsDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching video purchases for user {userId}: {ex.Message}");
                return new List<VideoPurchaseDetailsDto>();
            }
        }

        public async Task<IEnumerable<SeriesPurchaseDetailsDto>?> GetUserSeriesPurchasesAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/purchase/series/user/{userId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<IEnumerable<SeriesPurchaseDetailsDto>>(json, _jsonOptions);
                }
                return new List<SeriesPurchaseDetailsDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching series purchases for user {userId}: {ex.Message}");
                return new List<SeriesPurchaseDetailsDto>();
            }
        }
    }
}