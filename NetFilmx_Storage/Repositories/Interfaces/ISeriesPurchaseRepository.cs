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

        List<SeriesPurchase> GetAllSeriesPurchases();
        List<SeriesPurchase> GetSeriesPurchasesByUserId(int userId);
        List<SeriesPurchase> GetSeriesPurchasesBySeriesId(int seriesId);

        SeriesPurchase GetSeriesPurchaseById(int seriesPurchaseId);

        void AddSeriesPurchase(SeriesPurchase seriesPurchase);
        void UpdateSeriesPurchase(SeriesPurchase seriesPurchase);
        void DeleteSeriesPurchase(int seriesPurchaseId);

        bool IsSeriesPurchaseExist(int seriesPurchaseId);
        bool IsSeriesPurchaseExist(int userId, int seriesId);



    }
}
