using System.ComponentModel.DataAnnotations;

namespace NetFilmx_Service.Dtos.Favorite
{
    public class FavoriteAddDto : IFavoriteDto
    {
        public FavoriteAddDto() { }

        public FavoriteAddDto(int userId, int? videoId = null, int? seriesId = null)
        {
            UserId = userId;
            VideoId = videoId;
            SeriesId = seriesId;
        }

        [Required]
        public int UserId { get; set; }

        public int? VideoId { get; set; }

        public int? SeriesId { get; set; }
    }
}