﻿using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public sealed class DeleteVideoPurchaseCommandHandler : IRequestHandler<DeleteVideoPurchaseCommand, CResult>
    {
        private readonly IVideoPurchaseRepository _repository;

        public DeleteVideoPurchaseCommandHandler(IVideoPurchaseRepository repository)
        {
            _repository = repository;
        }

        public async Task<CResult> Handle(DeleteVideoPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            try
            {
                await _repository.DeleteVideoPurchaseAsync(command.VideoId, command.UserId);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }


        }

    }
}
