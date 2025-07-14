using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Cart.Delete
{
    public class RemoveCartItemCommandHandler : IRequestHandler<RemoveCartItemCommand, CResult>
    {
        private readonly ICartRepository _cartRepository;

        public RemoveCartItemCommandHandler(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CResult> Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Remove cart item
                await _cartRepository.RemoveCartItemAsync(request.CartItemId);

                return CResult.Success();
            }
            catch (ArgumentException ex)
            {
                return CResult.Failure(ex.Message);
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error removing cart item: {ex.Message}");
            }
        }
    }
}