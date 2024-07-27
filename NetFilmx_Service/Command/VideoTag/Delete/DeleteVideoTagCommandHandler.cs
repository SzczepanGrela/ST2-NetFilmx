using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFilmx_Service.Command.VideoTag.Delete
{
    public sealed class DeleteVideoTagCommandHandler : ICommandHandler<DeleteVideoTagCommand>
    {
        private readonly IVideoTagRepository _repository;


        public DeleteVideoTagCommandHandler(IVideoTagRepository repository)
        {
            _repository = repository;
        }


        public Result Handle(DeleteVideoTagCommand command)
        {

            var VideoTag = _repository.GetVideoTagByVideoIdTagId(command.Video_Id, command.Tag_Id);

            if (VideoTag == null)
            {
                return Result.Fail("Connection between this Video and Tag does not exist");
            }

            _repository.DeleteVideoTag(VideoTag.Id);

            return Result.Ok();
        }


    }
}
