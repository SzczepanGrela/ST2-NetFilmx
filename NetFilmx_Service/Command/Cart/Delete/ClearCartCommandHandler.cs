using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Command.Cart.Delete
{
    public class ClearCartCommandHandler : IRequestHandler<ClearCartCommand, CResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public ClearCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<CResult> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult.Failure("User not found");
                }

                // Clear cart for user
                await _cartRepository.ClearCartByUserIdAsync(request.UserId);

                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error clearing cart: {ex.Message}");
            }
        }
    }
}