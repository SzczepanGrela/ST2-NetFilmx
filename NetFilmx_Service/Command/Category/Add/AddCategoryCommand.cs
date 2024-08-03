using MediatR;

namespace NetFilmx_Service.Command.Category
{
    public sealed class AddCategoryCommand : IRequest<CResult>
    {
        public AddCategoryCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; }
        public string? Description { get; }

    }
}
