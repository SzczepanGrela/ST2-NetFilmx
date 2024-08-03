namespace NetFilmx_Service.Dtos.VideoPurchase
{
    public class VideoPurchaseListDto : IVideoPurchaseDto
    {
        public VideoPurchaseListDto(int videoId, int userId, DateTime purchaseDate)
        {
            VideoId = videoId;
            UserId = userId;
            PurchaseDate = purchaseDate;
        }

        public int VideoId { get; }

        public int UserId { get; }

        public DateTime PurchaseDate { get; }

    }
}
