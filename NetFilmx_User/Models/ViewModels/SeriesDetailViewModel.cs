using NetFilmx_Service.Dtos.Series;
using NetFilmx_Service.Dtos.Video;

namespace NetFilmx_User.Models.ViewModels
{
    public class SeriesDetailViewModel
    {
        public SeriesDetailsDto Series { get; set; } = null!;
        public List<VideoListDto> Episodes { get; set; } = new List<VideoListDto>();
        public int TotalEpisodes => Episodes.Count;
        public int WatchedEpisodes { get; set; } = 0;
        public decimal SeriesPrice { get; set; } = 29.99m;
        public bool IsUserOwner { get; set; }
    }
}