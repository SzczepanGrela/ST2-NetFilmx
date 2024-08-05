using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Like
{
    public sealed class GetLikesCountByVideoIdQueryHandler : IRequestHandler<GetLikesCountByVideoIdQuery, QResult<int>>

    {
        private readonly ILikeRepository _repository;

        public GetLikesCountByVideoIdQueryHandler(ILikeRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetLikesCountByVideoIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetLikesCountByVideoIdAsync(query.VideoId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
