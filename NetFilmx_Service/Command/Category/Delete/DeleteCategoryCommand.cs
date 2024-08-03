using MediatR;

namespace NetFilmx_Service.Command.Category
{
    public sealed class DeleteCategoryCommand : IRequest<CResult>
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }

    }
}
