using MediatR;



namespace NetFilmx_Service.Query.Category
{
    public sealed class GetCategoryByIdQuery<TDto> : IRequest<QResult<TDto>>
    {
        public int Id { get; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
