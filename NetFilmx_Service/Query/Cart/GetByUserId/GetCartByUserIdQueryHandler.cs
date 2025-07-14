using AutoMapper;
using MediatR;
using NetFilmx_Service.Dtos.Cart;
using NetFilmx_Service.Result;
using NetFilmx_Storage.Repositories;

namespace NetFilmx_Service.Query.Cart.GetByUserId
{
    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery<CartDetailsDto>, CResult<CartDetailsDto>>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public GetCartByUserIdQueryHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        public async Task<CResult<CartDetailsDto>> Handle(GetCartByUserIdQuery<CartDetailsDto> request, CancellationToken cancellationToken)
        {
            try
            {
                var cart = await _cartRepository.GetOrCreateByUserIdAsync(request.UserId);
                
                var cartDto = new CartDetailsDto
                {
                    Id = cart.Id,
                    UserId = cart.UserId,
                    CreatedAt = cart.CreatedAt,
                    UpdatedAt = cart.UpdatedAt,
                    CartItems = cart.CartItems.Select(ci => new CartItemDetailsDto
                    {
                        Id = ci.Id,
                        CartId = ci.CartId,
                        VideoId = ci.VideoId,
                        SeriesId = ci.SeriesId,
                        Quantity = ci.Quantity,
                        AddedAt = ci.AddedAt,
                        Title = ci.Video?.Title ?? ci.Series?.Name ?? "Unknown",
                        Price = ci.Video?.Price ?? ci.Series?.Price ?? 0,
                        ThumbnailUrl = ci.Video?.ThumbnailUrl ?? "/images/placeholder.jpg",
                        ItemType = ci.VideoId.HasValue ? "Video" : "Series"
                    }).ToList()
                };

                return CResult<CartDetailsDto>.Success(cartDto);
            }
            catch (Exception ex)
            {
                return CResult<CartDetailsDto>.Failure($"Error getting cart: {ex.Message}");
            }
        }
    }
}