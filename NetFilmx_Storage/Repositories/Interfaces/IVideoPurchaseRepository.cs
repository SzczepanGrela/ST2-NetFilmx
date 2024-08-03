using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface IVideoPurchaseRepository
    {

        Task<List<VideoPurchase>> GetAllVideoPurchasesAsync();

        Task<List<VideoPurchase>> GetVideoPurchasesByUserIdAsync(int userID);

        Task<List<VideoPurchase>> GetVideoPurchasesByVideoIdAsync(int videoId);

        Task<VideoPurchase> GetVideoPurchaseByUserIdVideoIdAsync(int userid, int videoid);

        Task<VideoPurchase> GetVideoPurchaseByIdAsync(int videoPurchaseId);

        Task AddVideoPurchaseAsync(VideoPurchase videoPurchase);
        Task UpdateVideoPurchaseAsync(VideoPurchase videoPurchase);
        Task DeleteVideoPurchaseAsync(int videoId, int userId);


        Task<bool> IsVideoPurchaseExistAsync(int videoPurchaseId);
        Task<bool> IsVideoPurchaseExistAsync(int userId, int videoId);
    }
}
