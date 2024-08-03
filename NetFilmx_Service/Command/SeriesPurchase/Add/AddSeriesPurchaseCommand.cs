using MediatR;

namespace NetFilmx_Service.Command.SeriesPurchase
{
    public sealed class AddSeriesPurchaseCommand : IRequest<CResult>
    {

        public AddSeriesPurchaseCommand(int seriesId, int userId)
        {
            SeriesId = seriesId;
            UserId = userId;
        }

        public int SeriesId { get; }
        public int UserId { get; }
        public DateTime PurchaseDate { get; }
    }
}
