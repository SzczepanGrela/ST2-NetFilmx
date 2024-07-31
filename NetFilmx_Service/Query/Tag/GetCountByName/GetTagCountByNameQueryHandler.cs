using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Query.Tag
{
    public sealed class GetTagCountByNameQueryHandler : IRequestHandler<GetTagCountByNameQuery, QResult<int>>
    {
        private readonly ITagRepository _repository;

        public GetTagCountByNameQueryHandler(ITagRepository repository)
        {
            _repository = repository;
        }

        public async Task<QResult<int>> Handle(GetTagCountByNameQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = await _repository.GetTagCountByNameAsync(query.TagName);
                return QResult<int>.Ok(count);
            }
            catch (Exception ex)
            {
                return QResult<int>.Fail(ex.Message);
            }
        }
    }
}
