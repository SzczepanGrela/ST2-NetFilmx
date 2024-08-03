namespace NetFilmx_Service.Dtos.VideoPurchase
{
    public class VideoPurchaseDetailsDto : IVideoPurchaseDto
    {
        public VideoPurchaseDetailsDto(int userId, int videoId, DateTime purchaseDate)
        {
            UserId = userId;
            VideoId = videoId;
            PurchaseDate = purchaseDate;
        }

        public int UserId { get; }

        public int VideoId { get; }

        public DateTime PurchaseDate { get; }


    }
}
