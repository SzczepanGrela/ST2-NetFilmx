using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Like.GetCountByVideoId
{
    public sealed class GetLikesCountByVideoIdQueryHandler : IQueryHandler<GetLikesCountByVideoIdQuery, int >
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
