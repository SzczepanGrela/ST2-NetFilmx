using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.SeriesPurchase
{
    public class SeriesPurchaseDetailsDto : ISeriesPurchaseDto
    {
        public SeriesPurchaseDetailsDto(int id, int userId, int seriesId, DateTime purchaseDate)
        {
            UserId = userId;
            SeriesId = seriesId;
            PurchaseDate = purchaseDate;
            Id = id;
        }

        public int Id { get; }
        public int UserId { get; }

        public int SeriesId { get; }

        public DateTime PurchaseDate { get; }


    }
}
