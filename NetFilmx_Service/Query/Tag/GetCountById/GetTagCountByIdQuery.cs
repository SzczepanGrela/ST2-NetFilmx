using MediatR;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByIdQuery : IRequest<QResult<int>>
    {
        public GetTagCountByIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
