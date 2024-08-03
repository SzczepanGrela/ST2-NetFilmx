namespace NetFilmx_Service.Dtos.Like
{
    public class LikeAddDto
    {


        public LikeAddDto(int videoId, int userId)
        {

            VideoId = videoId;
            UserId = userId;

        }


        public int VideoId { get; }

        public int UserId { get; }


    }
}
