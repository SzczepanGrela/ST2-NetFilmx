using NetFilmx_Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Storage.Repositories
{
    public interface ISeriesPurchaseRepository
    {


        Task<List<SeriesPurchase>> GetAllSeriesPurchasesAsync();
        Task<List<SeriesPurchase>> GetSeriesPurchasesByUserIdAsync(int userId);
        Task<List<SeriesPurchase>> GetSeriesPurchasesBySeriesIdAsync(int seriesId);

        Task<SeriesPurchase> GetSeriesPurchaseByIdAsync(int seriesPurchaseId);

        Task AddSeriesPurchaseAsync(SeriesPurchase seriesPurchase);
        Task UpdateSeriesPurchaseAsync(SeriesPurchase seriesPurchase);
        Task DeleteSeriesPurchaseAsync(int seriesPurchaseId);

        Task<bool> IsSeriesPurchaseExistAsync(int seriesPurchaseId);
        Task<bool> IsSeriesPurchaseExistAsync(int userId, int seriesId);



    }
}
