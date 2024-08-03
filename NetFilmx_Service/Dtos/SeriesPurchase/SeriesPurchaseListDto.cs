namespace NetFilmx_Service.Dtos.SeriesPurchase
{
    public class SeriesPurchaseListDto : ISeriesPurchaseDto
    {
        public SeriesPurchaseListDto(int userId, int seriesId, DateTime purchaseDate)
        {
            UserId = userId;
            SeriesId = seriesId;
            PurchaseDate = purchaseDate;
        }

        public int UserId { get; }

        public int SeriesId { get; }

        public DateTime PurchaseDate { get; }


    }
}
