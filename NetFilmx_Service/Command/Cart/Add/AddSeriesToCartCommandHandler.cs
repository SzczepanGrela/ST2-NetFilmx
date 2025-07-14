using MediatR;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;
using NetFilmx_Storage.Entities;

namespace NetFilmx_Service.Command.Cart.Add
{
    public class AddSeriesToCartCommandHandler : IRequestHandler<AddSeriesToCartCommand, CResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly ISeriesRepository _seriesRepository;
        private readonly IUserRepository _userRepository;

        public AddSeriesToCartCommandHandler(
            ICartRepository cartRepository,
            ISeriesRepository seriesRepository,
            IUserRepository userRepository)
        {
            _cartRepository = cartRepository;
            _seriesRepository = seriesRepository;
            _userRepository = userRepository;
        }

        public async Task<CResult> Handle(AddSeriesToCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validate user exists
                if (!await _userRepository.IsUserExistAsync(request.UserId))
                {
                    return CResult.Failure("User not found");
                }

                // Validate series exists
                if (!await _seriesRepository.IsSeriesExistAsync(request.SeriesId))
                {
                    return CResult.Failure("Series not found");
                }

                // Get or create cart for user
                var cart = await _cartRepository.GetOrCreateByUserIdAsync(request.UserId);

                // Check if series already in cart
                if (cart.CartItems.Any(ci => ci.SeriesId == request.SeriesId))
                {
                    return CResult.Failure("Series is already in cart");
                }

                // Add series to cart
                await _cartRepository.AddSeriesToCartAsync(cart.Id, request.SeriesId);

                return CResult.Success();
            }
            catch (Exception ex)
            {
                return CResult.Failure($"Error adding series to cart: {ex.Message}");
            }
        }
    }
}