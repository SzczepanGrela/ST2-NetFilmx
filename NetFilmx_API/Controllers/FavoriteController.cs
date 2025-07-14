using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NetFilmx_Service.Query.Favorite;
using NetFilmx_Service.Command.Favorite;
using NetFilmx_Service.Dtos.Favorite;
using NetFilmx_Service.Result;

namespace NetFilmx_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Get user favorites
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<FavoriteListDto>>> GetUserFavorites(int userId)
        {
            var query = new GetFavoritesByUserIdQuery<FavoriteListDto>(userId);
            var result = await _mediator.Send(query);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(result.Data);
        }

        /// <summary>
        /// Add video to favorites
        /// </summary>
        [HttpPost("user/{userId}/video/{videoId}")]
        public async Task<ActionResult> AddVideoToFavorites(int userId, int videoId)
        {
            var command = new AddFavoriteCommand(userId, videoId: videoId);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Video added to favorites", favoriteId = ((CResultWithData)result).Data });
        }

        /// <summary>
        /// Add series to favorites
        /// </summary>
        [HttpPost("user/{userId}/series/{seriesId}")]
        public async Task<ActionResult> AddSeriesToFavorites(int userId, int seriesId)
        {
            var command = new AddFavoriteCommand(userId, seriesId: seriesId);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Series added to favorites", favoriteId = ((CResultWithData)result).Data });
        }

        /// <summary>
        /// Remove from favorites
        /// </summary>
        [HttpDelete("{favoriteId}")]
        public async Task<ActionResult> RemoveFromFavorites(int favoriteId)
        {
            var command = new DeleteFavoriteCommand(favoriteId);
            var result = await _mediator.Send(command);
            
            if (result.IsFailure)
            {
                return BadRequest(new { 
                    Message = result.Message, 
                    Errors = result.Errors 
                });
            }

            return Ok(new { message = "Removed from favorites" });
        }
    }
}