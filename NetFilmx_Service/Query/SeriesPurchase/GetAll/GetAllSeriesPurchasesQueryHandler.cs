using AutoMapper;
using NetFilmx_Service.Query.SeriesPurchase.GetByUserId;
using NetFilmx_Storage.Entities;
using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Query.SeriesPurchase.GetAll
{
    public sealed class GetAllSeriesPurchasesQueryHandler : IQueryHandler<GetAllSeriesPurchasesQuery, QResult<List<NetFilmx_Storage.Entities.SeriesPurchase>>>
    {
        private readonly ISeriesPurchaseRepository _repository;
        

        public GetAllSeriesPurchasesQueryHandler(ISeriesPurchaseRepository repository)
        {
            _repository = repository;
           
        }

        public QResult<List <NetFilmx_Storage.Entities.SeriesPurchase>> Handle(GetAllSeriesPurchasesQuery query)
        {


            List<NetFilmx_Storage.Entities.SeriesPurchase> seriesPurchasesDto;
            try
            {
                var seriesPurchases = _repository.GetAllSeriesPurchases();
                
                return QResult<List<NetFilmx_Storage.Entities.SeriesPurchase>>.Ok(seriesPurchases);
            }
            catch (Exception ex)
            {
                return QResult<List<NetFilmx_Storage.Entities.SeriesPurchase>>.Fail(ex.Message);
            }

        }
    }
}
