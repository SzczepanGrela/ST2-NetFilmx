using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace NetFilmx_Service.Query
{
    public interface IQueryHandler<in TQuery, TResult> where TQuery : IQuery<TResult> 
    {
        Task<QResult<TResult>> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
