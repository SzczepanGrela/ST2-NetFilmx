using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Favorite
{
    public sealed class AddFavoriteCommand : IRequest<CResult>
    {
        public AddFavoriteCommand(int userId, int? videoId = null, int? seriesId = null)
        {
            UserId = userId;
            VideoId = videoId;
            SeriesId = seriesId;
        }

        public int UserId { get; }
        public int? VideoId { get; }
        public int? SeriesId { get; }
    }
}