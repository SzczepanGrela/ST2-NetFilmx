using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_Service.Command.Cart;
using NetFilmx_Service.Query.Cart;
using NetFilmx_Service.Dtos.Cart;
using NetFilmx_Service.Result;
using System.ComponentModel.DataAnnotations;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CartController> _logger;

        public CartController(IMediator mediator, ILogger<CartController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get user's cart with all items
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<ActionResult<CartDetailsDto>> GetUserCart(int userId)
        {
            try
            {
                var query = new GetCartByUserIdQuery<CartDetailsDto>(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return NotFound(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cart for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Add video to cart
        /// </summary>
        [HttpPost("add-video")]
        public async Task<ActionResult> AddVideo([FromBody] AddVideoToCartRequest request)
        {
            try
            {
                var command = new AddVideoToCartCommand(request.UserId, request.VideoId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Video added to cart successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding video {VideoId} to cart for user {UserId}", request.VideoId, request.UserId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Add series to cart
        /// </summary>
        [HttpPost("add-series")]
        public async Task<ActionResult> AddSeries([FromBody] AddSeriesToCartRequest request)
        {
            try
            {
                var command = new AddSeriesToCartCommand(request.UserId, request.SeriesId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Series added to cart successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding series {SeriesId} to cart for user {UserId}", request.SeriesId, request.UserId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Remove item from cart
        /// </summary>
        [HttpDelete("item/{cartItemId}")]
        public async Task<ActionResult> RemoveItem(int cartItemId)
        {
            try
            {
                var command = new RemoveCartItemCommand(cartItemId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Item removed from cart successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing cart item {CartItemId}", cartItemId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Clear entire cart for user
        /// </summary>
        [HttpDelete("{userId}/clear")]
        public async Task<ActionResult> ClearCart(int userId)
        {
            try
            {
                var command = new ClearCartCommand(userId);
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Message = "Cart cleared successfully" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing cart for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Get cart item count for user
        /// </summary>
        [HttpGet("{userId}/count")]
        public async Task<ActionResult<int>> GetCartItemCount(int userId)
        {
            try
            {
                var query = new GetCartItemCountQuery(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(new { Count = result.Data });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting cart item count for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }
    }

    public class AddVideoToCartRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int VideoId { get; set; }
    }

    public class AddSeriesToCartRequest
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int SeriesId { get; set; }
    }
}