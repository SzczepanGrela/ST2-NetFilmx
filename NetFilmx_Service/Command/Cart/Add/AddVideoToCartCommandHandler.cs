using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Command.Cart.Add
{
    public class AddVideoToCartCommandHandler : IRequestHandler<AddVideoToCartCommand, CResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IUserRepository _userRepository;

        public AddVideoToCartCommandHandler(
            ICartRepository cartRepository,
            IVideoRepository videoRepository,
            IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _videoRepository = videoRepository;
            _userRepository = userRepository;
        }

        public async Task<CResult> Handle(AddVideoToCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult.Failure("User not found");
                }

                // Validate video exists
                if (!await _videoRepository.IsVideoExistAsync(request.VideoId))
                {
                    return CResult.Failure("Video not found");
                }

                // Get or create cart for user
                var cart = await _cartRepository.GetOrCreateByUserIdAsync(request.UserId);

                // Check if video already in cart
                if (cart.CartItems.Any(ci => ci.VideoId == request.VideoId))
                {
                    return CResult.Failure("Video is already in cart");
                }

                // Add video to cart
                await _cartRepository.AddVideoToCartAsync(cart.Id, request.VideoId);

                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error adding video to cart: {ex.Message}");
            }
        }
    }
}