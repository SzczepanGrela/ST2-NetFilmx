namespace NetFilmx_Service.Dtos.Like
{
    public class LikeDto : ILikeDto
    {
        // not sure if ill use it, but made just in case
        public LikeDto(int id, int videoId, int userId, DateTime createdAt)
        {
            Id = id;
            VideoId = videoId;
            UserId = userId;
            CreatedAt = createdAt;
        }


        public int VideoId { get; }

        public int Id { get; }

        public int UserId { get; }

        public DateTime CreatedAt { get; }


    }
}
