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
