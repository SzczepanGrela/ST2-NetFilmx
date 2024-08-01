using NetFilmx_Storage.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace NetFilmx_Service.Command.VideoPurchase
{
    public sealed class AddVideoPurchaseCommandHandler : IRequestHandler<AddVideoPurchaseCommand, CResult>
    {
        private readonly IVideoPurchaseRepository _videoPurchaseRepository;

        public AddVideoPurchaseCommandHandler(IVideoPurchaseRepository videoPurchaseRepository)
        {
            _videoPurchaseRepository = videoPurchaseRepository;
        }

        public async Task<CResult> Handle(AddVideoPurchaseCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return CResult.Fail("Command is null");
            }

            var videoPurchase = new NetFilmx_Storage.Entities.VideoPurchase(command.UserId, command.VideoId);
            try
            {
                _videoPurchaseRepository.AddVideoPurchaseAsync(videoPurchase);
                return CResult.Ok();
            }
            catch (Exception ex)
            {
                return CResult.Fail(ex.Message);
            }

            

        }

    }
}
