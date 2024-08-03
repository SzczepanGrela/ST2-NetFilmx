using NetFilmx_Storage.Entities;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesPurchaseRepository
    {

        Task<List<SeriesPurchase>> GetAllSeriesPurchasesAsync();


        Task<List<SeriesPurchase>> GetSeriesPurchasesByUserIdAsync(int userId);

        Task<List<SeriesPurchase>> GetSeriesPurchasesBySeriesIdAsync(int seriesId);



        Task<SeriesPurchase> GetSeriesPurchaseByUserIdSeriesIdAsync(int userid, int seriesid);

        Task<SeriesPurchase> GetSeriesPurchaseByIdAsync(int videoPurchaseId);




        Task AddSeriesPurchaseAsync(SeriesPurchase seriesPurchase);
        Task UpdateSeriesPurchaseAsync(SeriesPurchase seriesPurchase);
        Task DeleteSeriesPurchaseAsync(int seriesId, int userId);

        Task<bool> IsSeriesPurchaseExistAsync(int seriesPurchaseId);
        Task<bool> IsSeriesPurchaseExistAsync(int userId, int seriesId);



    }
}
