namespace NetFilmx_Service.Dtos.VideoPurchase
{
    public class VideoPurchaseAddDto : IVideoPurchaseDto
    {

        public VideoPurchaseAddDto()
        {
        }

        public VideoPurchaseAddDto(int userId, int videoId)
        {
            UserId = userId;
            VideoId = videoId;

        }


        public int VideoId { get; set; }

        public int UserId { get; set; }

    }
}
