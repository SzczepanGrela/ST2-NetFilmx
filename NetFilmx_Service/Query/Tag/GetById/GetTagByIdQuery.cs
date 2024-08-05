using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public GetTagByIdQuery(int tagId)
        {
            TagId = tagId;
        }
        public int TagId { get; }

    }
}
