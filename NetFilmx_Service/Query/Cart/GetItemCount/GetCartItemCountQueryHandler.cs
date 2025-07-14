using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Cart.GetItemCount
{
    public class GetCartItemCountQueryHandler : IRequestHandler<GetCartItemCountQuery, CResult<int>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IUserRepository _userRepository;

        public GetCartItemCountQueryHandler(ICartRepository cartRepository, IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _userRepository = userRepository;
        }

        public async Task<CResult<int>> Handle(GetCartItemCountQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult<int>.Failure("User not found");
                }

                var cart = await _cartRepository.GetOrCreateByUserIdAsync(request.UserId);
                var count = cart.CartItems.Count;

                return CResult<int>.Success(count);
            }
            catch (Exception ex)
            {
                return CResult<int>.Failure($"Error getting cart item count: {ex.Message}");
            }
        }
    }
}