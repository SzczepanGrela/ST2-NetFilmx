using NetFilmx_Service.Dtos.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Dtos.SeriesPurchase
{
    public class SeriesPurchaseAddDto : ISeriesPurchaseDto
    {
        public SeriesPurchaseAddDto()
        {
        }

        public SeriesPurchaseAddDto(int seriesId, int userId)
        {
            SeriesId = seriesId;
            UserId = userId;

        }


        public int SeriesId { get; set; }

        public int UserId { get; set; }

    }
}
