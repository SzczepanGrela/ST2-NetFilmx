using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_Service.Query.VideoPurchase;
using NetFilmx_Service.Query.SeriesPurchase;
using NetFilmx_Service.Dtos.VideoPurchase;
using NetFilmx_Service.Dtos.SeriesPurchase;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<PurchaseController> _logger;

        public PurchaseController(IMediator mediator, ILogger<PurchaseController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Get user's video purchase history
        /// </summary>
        [HttpGet("video/user/{userId}")]
        public async Task<ActionResult<IEnumerable<VideoPurchaseDetailsDto>>> GetUserVideoPurchases(int userId)
        {
            try
            {
                var query = new GetVideoPurchasesByUserIdQuery<VideoPurchaseDetailsDto>(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting video purchases for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Get user's series purchase history
        /// </summary>
        [HttpGet("series/user/{userId}")]
        public async Task<ActionResult<IEnumerable<SeriesPurchaseDetailsDto>>> GetUserSeriesPurchases(int userId)
        {
            try
            {
                var query = new GetSeriesPurchasesByUserIdQuery<SeriesPurchaseDetailsDto>(userId);
                var result = await _mediator.Send(query);

                if (result.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = result.Message,
                        Errors = result.Errors
                    });
                }

                return Ok(result.Data);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting series purchases for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }

        /// <summary>
        /// Get user's complete purchase history (both videos and series)
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult> GetUserPurchaseHistory(int userId)
        {
            try
            {
                var videoQuery = new GetVideoPurchasesByUserIdQuery<VideoPurchaseDetailsDto>(userId);
                var seriesQuery = new GetSeriesPurchasesByUserIdQuery<SeriesPurchaseDetailsDto>(userId);

                var videoResult = await _mediator.Send(videoQuery);
                var seriesResult = await _mediator.Send(seriesQuery);

                if (videoResult.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = $"Error fetching video purchases: {videoResult.Message}",
                        Errors = videoResult.Errors
                    });
                }

                if (seriesResult.IsFailure)
                {
                    return BadRequest(new
                    {
                        Message = $"Error fetching series purchases: {seriesResult.Message}",
                        Errors = seriesResult.Errors
                    });
                }

                return Ok(new
                {
                    VideoPurchases = videoResult.Data ?? new List<VideoPurchaseDetailsDto>(),
                    SeriesPurchases = seriesResult.Data ?? new List<SeriesPurchaseDetailsDto>()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting purchase history for user {UserId}", userId);
                return StatusCode(500, new { Message = "Internal server error" });
            }
        }
    }
}