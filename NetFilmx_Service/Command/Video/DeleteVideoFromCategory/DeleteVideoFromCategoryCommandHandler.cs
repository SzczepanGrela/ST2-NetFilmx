using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.Video
{
    public sealed class DeleteVideoFromCategoryCommandHandler : IRequestHandler<DeleteVideoFromCategoryCommand, CResult>
    {
        private readonly IVideoRepository _repository;

        public DeleteVideoFromCategoryCommandHandler(IVideoRepository videoRepository)
        {
            _repository = videoRepository;
        }


        public async Task<CResult> Handle(DeleteVideoFromCategoryCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.RemoveVideoFromCategoryAsync(command.VideoId, command.CategoryId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }
            
        }


    }
}
