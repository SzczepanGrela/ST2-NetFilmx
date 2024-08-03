using MediatR;

namespace NetFilmx_Service.Command.Series
{
    public sealed class AddSeriesCommand : IRequest<CResult>
    {

        public AddSeriesCommand(string name, string? description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; }

        public string? Description { get; }

        public decimal Price { get; }


    }
}
