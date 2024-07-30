using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Query.Like.GetCountByVideoId
{
    public sealed class GetLikesCountByVideoIdQueryHandler : IQueryHandler<GetLikesCountByVideoIdQuery, QResult<int>>
    {
        private readonly ILikeRepository _repository;

        public GetLikesCountByVideoIdQueryHandler(ILikeRepository repository)
        {
            _repository = repository;
        }

        public QResult<int> Handle(GetLikesCountByVideoIdQuery query)
        {
            try
            {
                int count = _repository.GetLikesCountByVideoId(query.VideoId);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
