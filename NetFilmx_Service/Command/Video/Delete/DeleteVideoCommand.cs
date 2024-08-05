using MediatR;
using NetFilmx_Service.Result;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoCommand : IRequest<CResult>
    {

        public DeleteVideoCommand(int id)
        {

            Id = id;
        }

        public int Id { get; }


    }
}
