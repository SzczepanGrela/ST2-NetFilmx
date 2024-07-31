using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace NetFilmx_Service.Query
{
    public interface IQueryHandler<in TQuery, wantedType> where TQuery : IQuery<wantedType> 
    {
        Task<QResult<wantedType>> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
