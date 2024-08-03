using MediatR;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class DeleteSeriesPurchaseCommand : IRequest<CResult>
    {

        public DeleteSeriesPurchaseCommand(int seriesId, int userId)
        {
            SeriesId = seriesId;
            UserId = userId;
        }

        public int SeriesId { get; }

        public int UserId { get; }



    }
}
